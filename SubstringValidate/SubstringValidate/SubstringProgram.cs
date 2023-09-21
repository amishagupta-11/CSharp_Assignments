using System;
namespace SubStringProgram
{
    /// <summary>
    /// Adding class to check string occurences
    /// </summary>
    public class StringOccurence
    {

        /// <summary>
        /// method to find the occurence and indexes at which they are present
        /// </summary>
        /// <param name="strF"></param>
        /// <param name="strS"></param>
        public void CheckSubString(string strF,string strS)
        {
            //initializing count
            int count = 0;
            string position = " ";
           
            //checking if second string appears in first string 
            for (int i = 0; i <= strF.Length - strS.Length; i++)
            {
                bool found = true;
                //for every i value in string one this will iterate for whole second string 
                for (int j = 0; j < strS.Length; j++)
                {
                    //if the string hasnt appeared in the first string then terminate the for loop 
                    if (strF[i + j] != strS[j])
                    {
                        found = false;
                        break;
                    }
                }
                  //if the string has appeared then increment the count
                if (found)
                {
                    count++;
                    position = position + " " + i;
                }
            }
            //print the count and index positions
            Console.WriteLine("No. of times occurred = " + count);
            Console.Write("Index positions = "+position);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the first string:");
            string firstString = Console.ReadLine();

            Console.WriteLine("Enter the second string:");
            string secondString = Console.ReadLine();
            //creating an object to call the method
            StringOccurence obj = new StringOccurence();
            //calling the method from main method
            obj.CheckSubString(firstString, secondString);
        }
    }
}


