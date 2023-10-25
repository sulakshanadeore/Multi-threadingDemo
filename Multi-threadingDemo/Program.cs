using System;

using System.Threading;

namespace Multi_threadingDemo
{
    public class Program
    {

        //public delegate void ParameterizedThreadStart(object obj);
        //public delegate void ThreadStart();
        public static void Print()
        {
            int i = 9;
            for (int j = 0; j <i; j++)
            {
                Console.WriteLine(j);

                Thread.Sleep(1);//Suspend the thread for 1 milliseconds
            }
        }


        public static void Greet()
        {
            Console.WriteLine("Good morning..................");

        }


        static void Main(string[] args)
        {
            //CurrentThreadExample();
            //ThreadingBasics();


            //Thread firstThread = new Thread(new ThreadStart(Print));
            //Thread secondThread = new Thread(new ThreadStart(Print));
            //firstThread.Start();
            //secondThread.Start();



            






            Console.Read();
        }

        private static void ThreadingBasics()
        {
            //no safety---
            //Thread tobj = new Thread(Program.Greet);
            //tobj.Start();


            //it can any method which takes a object(any data type) and returns void

            ThreadStart del = new ThreadStart(Program.Print);
            Thread t = new Thread(del);

            //Thread t = new Thread(new ThreadStart(Program.Print));

            //anonymous type for threadstart delegate
            Thread t2 = new Thread(new ThreadStart(Program.Greet));
            t.Start();
            //When the output differs on every execution in case of multithreading its called "Context Switching".
            //Context switching will happen whether its a instance method or static method used with the delegate


            Console.WriteLine("---------");
            Console.WriteLine($"Managed Print Thread id={t.ManagedThreadId}");//3
            t2.Start();
            Console.WriteLine($"Managed Greeting Thread id={t2.ManagedThreadId}");//4
        }

        private static void CurrentThreadExample()
        {
            Thread t = Thread.CurrentThread;
            t.Name = "This method ie Main method is running";
            Console.WriteLine(t.Name);
            Console.WriteLine(t.ManagedThreadId);
        }
    }
}

