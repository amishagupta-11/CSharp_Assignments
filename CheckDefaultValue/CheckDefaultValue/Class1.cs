using System;
using System.Threading;

namespace CheckDefaultValue
{
    public class Class1
    {
        public static void task1()
        {
            int a = 10;
            int b = 20;
            int c = a+b;
            Console.WriteLine("Task1 value:"+c);
        }
        public static void task2()
        {
            int a = 20;
            int b = 40;
            int c = a+b;
            Console.WriteLine("Task2 value:"+c);
        }

    }
    public class ThreadExample
    {
        public static void Main(string[] args) {
            Thread t1= new Thread(new ThreadStart(Class1.task1));
            Thread t2 = new Thread(new ThreadStart(Class1.task2));
            t1.Start();
            t2.Start();



        }
    }
}
