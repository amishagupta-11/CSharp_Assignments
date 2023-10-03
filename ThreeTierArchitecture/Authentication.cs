using BusinessLayer;
using System;
using UserDetails;

namespace PresentationLayer
{
    public  class Authentication
    {       
        /// <summary>
        /// method to take user input to register themselves in system.
        /// </summary>
        public void Register()
        {
            BAuthentication bCheck = new BAuthentication (); 
            UserInput userObj=new UserInput();
            Console.Write("Please Enter your email:");
            userObj.email = Console.ReadLine();
            Console.WriteLine("Enter your username: ");
            userObj.username = Console.ReadLine();
            while(bCheck.IsUsernameExists(userObj))
            {
                Console.WriteLine("Username Not available");
                Console.WriteLine("Please re-enter your username:");
                userObj.username=Console.ReadLine();
            }
            if(!bCheck.IsUsernameExists(userObj))
            {
                Console.WriteLine("Username available");
            }
            Console.WriteLine("Enter your password: ");
            userObj.password=Console.ReadLine();
            if (!bCheck.IsPassword(userObj))
            {
                Console.WriteLine("Please Make sure your password is of maximum length of 10 and consists of atleast one numeric value"+
                                 "\nspecial character,\nUppercase letters,\nlowercase letters");
                Console.WriteLine("Please enter your password: ");
                userObj.password=Console.ReadLine();
                
            }
            if(bCheck.IsPassword(userObj))
            {
                Console.WriteLine("Re-Enter your Password: ");
                userObj.confirmPassword = Console.ReadLine();
            }
            bool isMatch = bCheck.IsPasswordMatch(userObj);
            if (isMatch)
            {

                Console.WriteLine("Password Matched");
            }
            else
            {
                Console.WriteLine("Password Mismatch.please try again");
            }
            if (bCheck.RegisteredUser(userObj))
            {
                Console.WriteLine("Registration Successful");
            }
            else
            {
                Console.WriteLine("Registration failed.please try again.");
                Register();
            }
        }
        /// <summary>
        ///method to allow users to login into the system and providing the option to reset password. 
        /// </summary>

        public void Login()
        {
            UserInput userObj = new UserInput();
            BAuthentication bCheck = new BAuthentication();
            Console.WriteLine("Enter your Username ");
            userObj.username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            userObj.password=Console.ReadLine();
            if (bCheck.LoginHere(userObj))
            {
                if (bCheck.LoginSuccess(userObj))
                {
                    Console.WriteLine("Login Successful!");
                }
                else
                {
                    Console.WriteLine("Login Failed!");
                    string response;
                    Console.WriteLine("Forget Password?(yes/no)");
                    Console.Write("Response: ");
                    response= (Console.ReadLine());
                    if (response=="Yes"||response=="yes")
                    {
                        //method call to the reset the password if they choose the forget password option.
                       ResetPassword();
                    }
                    else
                    {
                        //recursive call to LoginHere() method if user doesn't want to reset the password.
                        Login();
                    }

                }
            }
            else
            {
                Console.WriteLine("Invalid username or password.Please Try again!");
                Login();
            }
        }
        /// <summary>
        /// method to reset the user password by validating their details in case they forget and fail to login into the system.
        /// </summary>
        public void ResetPassword()
        {
            UserInput userObj = new UserInput();
            BAuthentication bCheck = new BAuthentication();
            Console.WriteLine("Please enter your Email-id: ");
            userObj.email=Console.ReadLine();
            if (bCheck.IsValidEmail(userObj))
            {
                Console.WriteLine("Please enter your Username: ");
                userObj.username=Console.ReadLine();
                if (bCheck.IsValidUsername(userObj))
                {
                    Console.WriteLine("Verified User");
                    ChangedPassword();
                }
                else
                {
                    Console.WriteLine("Enter a valid Username:");
                    ResetPassword();
                }
            }
            else
            {
                Console.WriteLine("Enter a valid email.");
                ResetPassword();
            }
        }
        /// <summary>
        /// method helps in updating the data in the database and lets user know whether the password was successfully
        /// updated or not.
        /// </summary>
        public void ChangedPassword()
        {
            UserInput userObj = new UserInput();
            BAuthentication bCheck = new BAuthentication();
            Console.WriteLine("Please enter your new Password: ");
            userObj.password=Console.ReadLine();
            if (bCheck.IsPasswordMatch(userObj))
            {
                if (bCheck.IsPasswordUpdate(userObj.password,userObj.username))
                {
                    Console.WriteLine("Password updated Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Password Updation Failed.please try again.");
                    ResetPassword();
                }
            }
            else
            {
                Console.WriteLine("Please Make sure Your password is of maximum length of 10 and consists of atleast one numeric value"+
                                   "\nspecial character,\nUppercase letters,\nlowercase letters");
                ChangedPassword();
            }
        }
    }
}
