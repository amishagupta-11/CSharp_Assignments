using System;
namespace MaxProduct
{
    
    public class MaxAdjacentProduct
    {        
        /// <summary>
        /// method to find the maximum product in the input given by the user
        /// </summary>
        /// <param name="input"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static long  FindingProduct(string input,int digits)
        {
            //declaring the maximum product variable to store the maximum product value
            long maxProduct = 0;
            //declaring a string to store the digits that will result the product
            string nums = "";            
            for(int i=0;i<=input.Length-digits;i++)
            {
                 nums = "";
                long product = 1;
                for(int j = 0; j<digits; j++)
                {
                    //parsing the string value to int value 
                    int num = int.Parse(input[i + j].ToString());
                    //appending the number to string variable
                    nums+=num;
                    product *= num;
                }
                //checking the product value for every iteration to obtain the Max value.
                //if the value found to be max then the maximum product will be the product value 
                if (product > maxProduct)
                {
                    maxProduct = product;
                 }
            }
            int m = nums.Length;
            Console.Write(nums[m-4]+"*"+nums[m-3]+"*"+nums[m-2]+"*"+nums[m-1]+"=");            
            return maxProduct;
        }
    }
}






                

            
        
    