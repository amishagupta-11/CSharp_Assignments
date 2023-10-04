using System;
using UserDetails;
using BusinessLayer;

namespace PresentationLayer
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Authentication loginObj = new Authentication();
            string end;
            Console.WriteLine("Welcome...");
            do
            {
                Console.WriteLine("Please Select any one from the below Options.");
                Console.WriteLine("1.Login\n2.New User");
                Console.Write("Option: ");
                int select = Int32.Parse(Console.ReadLine());
                if (select>0 && select<3)
                {
                    if (select==1)
                    {
                        loginObj.Login();

                    }
                    if (select==2)
                    {
                        loginObj.Register();

                    }
                }
                else
                {
                    Console.WriteLine("Please provide a valid input.");
                }
                Console.WriteLine("Do you want to exit?\npress 'y' to continue and any key to exit.");
                end=Console.ReadLine();
            } while (end=="y");
            Console.WriteLine(" !!!Thank you!!!");

        }
    }
}
