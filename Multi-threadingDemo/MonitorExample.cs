using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_threadingDemo
{
    class MonitorDemo
    {
        static object obj=new object();
        public static void Print()
        {
            try
            {
                //Accepting the account number
                //accepting the amount
                //you have the balance known to you in the account
                //exclusive lock using Monitor.Enter
                Monitor.Enter(obj);
                try
                {
                    int i = 9;
                    for (int j = 0; j < i; j++)
                {

                    Console.Write("Value of the loop=" + j + "\t");
                    Thread t = Thread.CurrentThread;
                    Console.WriteLine("current thread executing =" + t.Name);
                    Thread.Sleep(200);//Suspend the thread for 200 milliseconds
                }
                }
                finally
                {
                    Monitor.Exit(obj);//Releases the lock
                }

            }
            catch(SynchronizationLockException ex) 
            {
                Console.WriteLine( ex.Message);

            }

        }
    }

    internal class MonitorExample
    {

        

        static void Main(string[] args)
        {
             Thread t = new Thread(MonitorDemo.Print);
            Thread[] tasks = new Thread[3];
                MonitorDemo md=new MonitorDemo();                       

            for (int i = 0; i < 3; i++)
            {
                tasks[i] = new Thread(new ThreadStart(MonitorDemo.Print));
                tasks[i].Name = i.ToString() + "Thread";
            }
            foreach (Thread item in tasks)
            {
                item.Start();
            }

            Console.ReadLine();
        }
    }
}
