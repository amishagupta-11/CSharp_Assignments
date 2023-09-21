using System;

namespace SingleTonInstanceCheck
{
    public class Program { 
        /// <summary>
        /// specific method to display the results using 2 integers
        /// </summary>
        /// <param name="firstNum"></param>
        /// <param name="secNum"></param>
        public void Display(int firstNum,int secNum)
        {
            Console.WriteLine("Summation Result:"+firstNum);
            Console.WriteLine("Multiplication Result:"+secNum);
        }
        /// <summary>
        /// main method to call all the methods
        /// </summary>
        public static void Main()
        {
            //Creating current class object 
            Program pg= new Program();

           //Creating first object of singletoncheck class 
            Console.WriteLine("calling with First object");
            SingletonCheck instance =SingletonCheck.Inst_check();
            instance.ChatBot();
            int res_First=instance.Operations(11,21);
            int res_Firs = instance.Multiplication(12, 22);
            pg.Display(res_First,res_Firs);

            Console.WriteLine("===========================");
            //creating second object of singletoncheck class
            Console.WriteLine("calling with Second object");
            SingletonCheck secObj = SingletonCheck.Inst_check();
            int res_Sec= secObj.Operations(13, 23);
            int res_Second=secObj.Multiplication(14, 24);
            pg.Display(res_Sec, res_Second);

            Console.WriteLine("===========================");
            //creating third object of singletoncheck class
            Console.WriteLine("calling with Third object");
            SingletonCheck thirdObj = SingletonCheck.Inst_check();
            int res_Third=thirdObj.Operations(15, 25);
            int res_Thir=thirdObj.Multiplication(16, 27);
            pg.Display(res_Third, res_Thir);

            

 


       

        }
    }
}

