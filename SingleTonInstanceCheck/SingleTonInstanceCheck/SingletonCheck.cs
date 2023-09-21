using System;
using System.Diagnostics.CodeAnalysis;

namespace SingleTonInstanceCheck
{
    /// <summary>
    /// creating a sealed class for checking whether multiple instances are being created or not
    /// </summary>
    public sealed class SingletonCheck
    {
        private SingletonCheck() { }
        public static int count = 0;
        private static SingletonCheck instance = null;
        /// <summary>
        /// specific method to check the whether single instance is present or not
        /// </summary>
        /// <returns></returns>
        public static SingletonCheck Inst_check()
        {
            if (instance == null)
            {
                instance = new SingletonCheck();
                SingletonCheck.count++;

            }
            return instance;
        }
        /// <summary>
        /// general method for implementation
        /// </summary>
        public void ChatBot()
        {
            Console.WriteLine("My name is Bunny...");
            Console.WriteLine("I am here to assist you!");
            Console.WriteLine("Instance Created :"+SingletonCheck.count);
        }
        /// <summary>
        /// specific method to find summation within a specific range
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
       public int Operations(int fVal,int sVal)
       {
            int sum = 0;
            for(int i = fVal; i<=sVal; i++)
            {
                sum+=i;                
            }
               return sum;
       }
        /// <summary>
        /// specific method to find product of numbers within a specific range
        /// </summary>
        /// <param name="fNum"></param>
        /// <param name="sNum"></param>
        /// <returns></returns>
        public int Multiplication(int fNum, int sNum)
        {
            int mul = 1;
            for (int i = fNum; i<=sNum; i++)
            {
                mul*=i;
            }
            return mul;
        }       

    }
}
