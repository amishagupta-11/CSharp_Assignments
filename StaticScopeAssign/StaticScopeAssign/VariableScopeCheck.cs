using System;

namespace ScopeTesting 
{
    /// <summary>
    /// Creating class for defining the different static and non-static variables
    /// </summary>
    public class VariableScopeCheck
    {
        //declaring and defining static variables
        public static int _resultStorage = 0;
        public static string Type = "Arithmetic";
        /// <summary>
        /// creating method to add 2 values
        /// </summary>
        /// <param name="fNum"></param>
        /// <param name="sNum"></param>
        /// <returns></returns>
        public static int Sum(int fNum, int sNum)
        {
            return fNum + sNum;
        }
        /// <summary>
        /// creating a method to return the value
        /// </summary>
        /// <param name="result"></param>
        public static void Store(int result)
        {
            _resultStorage = result;
        }
    }
    /// <summary>
    /// Creating a separate class for re-initializing the values and checking their scope
    /// </summary>
    class Validate
    {
        static void Main(string[] args)
        {
            // calling static method
            int result = VariableScopeCheck.Sum(10, 25);
            //displaying the value
            Console.WriteLine(result);
            // accessing static variable
            string calcType = VariableScopeCheck.Type;
            // assign value to static variable
            VariableScopeCheck.Type = "Scientific"; 
            Console.WriteLine(VariableScopeCheck.Type);
        }
    }
}