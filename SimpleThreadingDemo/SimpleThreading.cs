using System;
using System.Threading;

namespace SimpleThreadingDemo
{
    class SimpleThreading
    {
        static void Main(string[] args)
        {
            ThreadStart threadStarter = new ThreadStart(Counting);
            Thread firstThread = new Thread(threadStarter);
            Thread secondThread = new Thread(threadStarter);

            firstThread.Start();
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();

            Console.Read();
        }

        static void Counting()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Count: {0} - Thread: {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }
    }
}
