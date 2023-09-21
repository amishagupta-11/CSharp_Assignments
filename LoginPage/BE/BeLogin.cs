using System;
using DataAccess;
namespace BusinessLogic
{
    /// <summary>
    /// Specific class for all registration,login and forget password implementations.
    /// </summary>
    public class BeLogin
    {
        public string _username = "";
        public string _password = "";
        public string _Email = "";
        public string _gender = "";

        /// <summary>
        /// specific method for registration of a new user.
        /// </summary>
        public void Registration()
          {
            UserDA obj = new UserDA();     
            Console.WriteLine("Enter your Email-id: ");
            _Email = Console.ReadLine();
            Console.WriteLine("Enter your username: ");
            _username = Console.ReadLine();  
            //condition to check if the username is available or not in the database.
            while (obj.Verify(_username))
            {
                Console.WriteLine("Username Not available");
                Console.WriteLine("Please re-enter your username:");
                _username=Console.ReadLine();
            }
            if(!obj.Verify(_username))
            {

             Console.WriteLine("Username available.");
            }            
            Console.WriteLine("Enter your password: ");
             _password=Console.ReadLine();
            Console.WriteLine("Enter your gender: ");
             _gender = Console.ReadLine();  
            //method call for checking whether the user has been successfully registered or not.
            bool isRegistered=obj.RegisterUser(_Email, _username, _password,_gender);   
            if(isRegistered)
            {
                Console.WriteLine(" Registered successfully!!");
            }
            else
            {
                Console.WriteLine("Registration failed.please try again..");
            }
        }

        /// <summary>
        /// Specific method for user login into the system.
        /// </summary>
        public void LoginHere()
        {
            UserDA test=new UserDA();
            Console.WriteLine("Enter your Username ");
            string _username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string _password= Console.ReadLine();
            //method call to verify the details of user 
            bool validate = test.LoginUser(_username,_password);
            if (validate)
            {
                Console.WriteLine("Login Successful");
            }
            else
            {
                //block of code to let user get the option of "Forget password" if they input the incorrect details.
                string response;
                Console.WriteLine("Invalid email or password.Please Try again!");
                Console.WriteLine("Forget Password?");
                Console.Write("Response: ");
                 response= (Console.ReadLine());
                if(response=="Yes"||response=="yes")
                {
                    //method call to the reset the password if they choose the forget password option.
                  ResetPassword();
                }
                else
                {
                    //recursive call to LoginHere() method if user doesn't want to reset the password.
                    LoginHere();
                }
            }
        }

        /// <summary>
        /// Specific method to let user reset their existing password incase they forget the password.
        /// </summary>
        public void ResetPassword()
        {
            UserDA reset = new UserDA();
            Console.WriteLine("Please enter your Email-id: ");
            _Email=Console.ReadLine();
            Console.WriteLine("Please enter your Username: ");
            _username=Console.ReadLine();
            //condition and a method call to verify the user and if verified only then they can change the password.
            if (reset.validEmail(_Email)&&reset.Verify(_username))
            {
                Console.WriteLine("Verified User..");
                Console.WriteLine("Please enter your new Password: ");
                _password=Console.ReadLine();
                //condition to check if the password has been changed or not in the database.
                if (reset.UpdatePassword(_password,_Email)) 
                {                
                Console.WriteLine("Password has Successfully been updated.");
                }
            }
            while (!reset.validEmail(_Email)&&!reset.Verify(_username))
            {
                Console.WriteLine("Please enter a valid Email or username!");
            }

        }
    }
}