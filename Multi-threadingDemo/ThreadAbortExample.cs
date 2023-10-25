using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_threadingDemo
{
    public class MyThread
    {
        public  void Print()
        {
            int i = 9;
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine(j);
                Thread t=Thread.CurrentThread;
                Console.WriteLine("current thread executing =" + t.Name);
                Thread.Sleep(200);//Suspend the thread for 200 milliseconds
            }
        }
    }

    internal class ThreadAbortExample
    {

        
        static void Main(string[] args)
        {
            try {
                Console.WriteLine("Started main");
                MyThread ea=new MyThread();
             Thread firstThread = new Thread(new ThreadStart(ea.Print));
            Thread secondThread = new Thread(new ThreadStart(ea.Print));
            firstThread.Start();
            secondThread.Start();

            
                          
                firstThread.Abort();
                Console.WriteLine("First thread  aborted");

                secondThread.Abort();
                Console.WriteLine("second thread  aborted");
            }
            catch (ThreadAbortException ex)
            {

                Console.WriteLine("Thread aborted ......");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("End main");
            Console.ReadLine();
        }
    }
}
