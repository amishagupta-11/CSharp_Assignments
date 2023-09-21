using  System;
namespace Conversion
{
    /// <summary>
    /// Adding class for converting float values to binary and performing the required manipulations
    /// </summary>
    public class ConvertFloatToBinary
    {
        public static void Main()
        {
            //Taking inputs from user 
            Console.WriteLine("Enter first float value:");
            double m = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second float value:");
            double n = double.Parse(Console.ReadLine());

            //creating obj of the class
            FloatToBinConverter obj = new FloatToBinConverter();

            //calling the conversions() method
            //calling FLoatToBinary() method for converting float values to binary
            string valM = obj.FloatToBinary(m);
            string valN = obj.FloatToBinary(n);

            //displaying the binary strings obtained
            Console.WriteLine("Binary value for the First float value: "+valM);
            Console.WriteLine("Binary value for the Second float value: "+valN);

            //calling Binary_Addition method to add the strings
            Binary_Addition addB = new Binary_Addition();
            double result = addB.AddBinary(valM, valN);
            //displaying the result
            Console.WriteLine("Sum of the given numbers : "+ result);
        }

    }
}

       
        
          
      
