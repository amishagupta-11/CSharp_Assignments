using System;
using System.Runtime.CompilerServices;

namespace CheckDefaultValue
{
    public class Class2
    {

        public static void complexMath(int num, out int sqr, out int cube)
        {
            Thread.Sleep(2000);
           // Console.WriteLine(sqr);
            sqr = num * num;
            cube = num * num * num;
            Console.WriteLine("square of n value:{0}", sqr);
            Console.WriteLine("Cube of n value:{0}", cube);
        }
        static void Main(string[] args)
        {
            int n = 10;
            int sqr=0;
            int cube=0;
            Console.WriteLine("Value of sqr before calling the method: "+sqr);
            Console.WriteLine("Value of cube before calling the method: "+cube);
            Thread th = new Thread(() => complexMath(n, out sqr, out cube));
            th.Start();


        }
    }
}
