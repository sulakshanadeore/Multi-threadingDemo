using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Multi_threadingDemo
{

    
    
    internal class SemaphoreDemo
    {

        static void Process()
        {

            Console.WriteLine("{0} is waiting to enter the critical section  ", Thread.CurrentThread.Name);
            SemaphoreDemo.semaphore.WaitOne();
            Console.WriteLine("{0} is inside to enter the critical section  ", Thread.CurrentThread.Name);
            Thread.Sleep(1000);
            Console.WriteLine("{0} is releasing/exiting the enter the critical section  ", Thread.CurrentThread.Name);
            SemaphoreDemo.semaphore.Release();
        }

        
        public static Semaphore semaphore = new Semaphore(3, 5);

        static void Main(string[] args)
        {
            for (int i = 0; i < 7; i++)
            {
                Thread tobj = new Thread(Process);
                tobj.Name = "Thread " + i;
                tobj.Start();
            }
            Console.ReadLine();

        }
    }
}
