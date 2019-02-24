using System;
using System.Threading;

namespace ThreadClass
{
    public class ThreadClass
    {
        public static void Main(string[] args)
        {
            var t = new Thread(new ThreadStart(NonParameterizedThread));

            var pt = new Thread(new ParameterizedThreadStart(ParamerterizedThread));

            _DemoMethod("Main");
            pt.Start("Thread2");
            t.Start();
            t.Join();
            pt.Join();


            ThreadPool.QueueUserWorkItem(ThreadPoolThread, "asd");
            ThreadPool.QueueUserWorkItem(ThreadPoolThread, "bhoo");
            ThreadPool.QueueUserWorkItem(ThreadPoolThread, "ankur");
            ThreadPool.QueueUserWorkItem(ThreadPoolThread);
        }

        [ThreadStatic] //this makes _field local to each thread
        static int _field;

        static void ThreadPoolThread(object? stateInfo = null)
        {
            Console.WriteLine("Hello" + stateInfo?.ToString()); //null ref :P
        }

        static void NonParameterizedThread()
        {
            _DemoMethod(null);
        }

        static void ParamerterizedThread(object o)
        {
            if (o is string)
            {
                _DemoMethod(o as string);
            }
        }

        static void _DemoMethod(string? name)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{name ?? "thread"}: {_field}");
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                _field++;
                Thread.Sleep(0); //this forces program to switch context
            }
        }
    }
}
