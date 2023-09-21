using System;
namespace CheckDefaultValue
{

    public class Program
    {

        public static void Main()
        {
            int a = 10;
            Console.WriteLine(a);
            Thread th = new Thread(() =>CheckDefault.CalculateValues(out a));
            th.Start();
            th.Join();
            Console.WriteLine("After calling:"+a);
        }
    }
}