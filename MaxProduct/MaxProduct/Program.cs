using System;


namespace MaxProduct
{
    
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a number:");
            string input = Console.ReadLine();
            //fixing the digits according to the requirement
            int digits = 4;
            long maxProduct = MaxAdjacentProduct.FindingProduct(input, digits); 
            Console.WriteLine(maxProduct);
        }
    }
}
