using System;
using System.Threading;

namespace ThreadsWithWaitOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(CountUp))
            {
                Name = "||||||||||||",
            };
            Thread t2 = new Thread(new ThreadStart(CountUp))
            {
                Name = "------------",
            };

            t1.Start();
            t2.Start();
            Console.Read();
        }

        private static int Runs = 0;
        static Mutex mutex = new Mutex(false, "RunsMutex");
        public static void CountUp()
        {
            while (Runs < 100)
            {
                // acquire the mutex  
                mutex.WaitOne();
                Runs++;
                Console.WriteLine(Thread.CurrentThread.Name + " " + Runs);
                Thread.Sleep(200);
                // release the mutex  
                mutex.ReleaseMutex();
            }
        }
    }
}
