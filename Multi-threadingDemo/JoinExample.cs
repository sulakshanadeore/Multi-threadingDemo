using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_threadingDemo
{
    internal class JoinExample
    {
        static void Main(string[] args)
        {
            MyThread mt = new MyThread();
            Thread t1 = new Thread(new ThreadStart(mt.Print));
            Thread t2 = new Thread(new ThreadStart(mt.Print));
            Thread t3 = new Thread(new ThreadStart(mt.Print));
            t1.Name = "First Thread";
            t2.Name = "Second Thread";
            t3.Name = "Third Thread";

            t1.Start();
            t1.Join();
            t2.Start();
      
            t3.Start();
            Console.ReadLine();
        }
    }
}
