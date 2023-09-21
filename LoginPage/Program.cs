using System;
using DataAccess;
using BE;
namespace LoginPage 
{
    public class Program
    {
        public static void Main(String[] args)
        {
           BeLogin loginObj= new BeLogin();
            Console.WriteLine("Welcome...");
            Console.WriteLine("Please Select any one from the below suggestions");
            Console.WriteLine("1.Login\n2.New User\n3.Forget Password\n 4.Exit");
            int select=Int32.Parse(Console.ReadLine());
            while(select>0 && select<5)
            {
                if (select==1)
                {
                    loginObj.LoginHere();
                }
                if (select==2)
                {
                    loginObj.Registration();
                }
            }
        }
    }
}