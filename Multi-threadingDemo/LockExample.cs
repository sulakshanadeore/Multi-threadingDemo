using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_threadingDemo
{
    public class MyThreadForLock
    {

               public void Print()
        {
            //this means thread that has entered, it acquires a lock 
            //inclusive
            lock (this)
            {
                //Accepting the account number
                //accepting the amount
                //you have the balance known to you in the account

                int i = 9;
                for (int j = 0; j < i; j++)
                {
                    
                    Console.WriteLine(j);
                    Thread t = Thread.CurrentThread;
                    Console.WriteLine("current thread executing =" + t.Name);
                    Thread.Sleep(200);//Suspend the thread for 200 milliseconds
                }
            }
        }
    }


    internal class LockExample
    {
        static void Main(string[] args)
        {
            MyThreadForLock mt = new MyThreadForLock();
            Thread t1 = new Thread(new ThreadStart(mt.Print));
            Thread t2 = new Thread(new ThreadStart(mt.Print));
            //Thread t3 = new Thread(new ThreadStart(mt.Greet));

            t1.Name = "First Thread";
            t2.Name = "Second Thread";
            //t3.Name = "Third Thread";



            t1.Start();
            //t1.Join();
            t2.Start();
            //t3.Start();

            Console.Read();
        }
    }
}
