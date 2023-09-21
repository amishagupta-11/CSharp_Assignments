using System;
using System.Threading.Tasks;

namespace CheckDefaultValue
{
    public class CheckDefault
    {
        public static void CalculateValues(out int result)
        {
            // Simulate some calculation
            Thread.Sleep(1000);
            Thread thu = new Thread(Simple);
            thu.Start();
            Console.WriteLine(result);
            result = 42;

        }    public static void Simple()
        {

        }

        
    }
}
