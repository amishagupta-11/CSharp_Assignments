using System;
using System.Text.RegularExpressions;
using DataLayer;
using UserDetails;



namespace BusinessLayer
{
    /// <summary>
    /// Specific class for validating the data provided by the user
    /// </summary>
    public class BValidation
    {
        /// <summary>
        /// method to check if user haven't provided any required data 
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>

        public bool IsUserValid(UserInput userObj)
        {
            if(string.IsNullOrEmpty(userObj.username)||string.IsNullOrEmpty(userObj.password))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// method to check if user has provided the correct data that was provided at the time of registration. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Validate(UserInput userObj)
        {
            DataAccess access =new DataAccess();
            bool verified = access.LoginUser(userObj.username,userObj.password);
            if (verified)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// method to check if the email provided by the user is existing in the database or not.
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool IsEmail(UserInput userObj)
        {
            DataAccess access = new DataAccess();
            if (userObj.email!=null)
            {
                if (access.validEmail(userObj))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// method to check username provided by the user is present in the database or not
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool IsUsername(UserInput userObj)
        {
            DataAccess access = new DataAccess();
            if (userObj.username!=null)
            {
                return access.Verify(userObj);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// method to provide a constraint to enter the password by the user.
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool IsPasswordValid(UserInput userObj)
        {
            string pattern = @"^(?=.*[0-9])(?=.*[!@#$%^&*])[A-Za-z0-9!@#$%^&*]{10}$";
            return Regex.IsMatch(userObj.password, pattern);
        }
        /// <summary>
        /// method to update the password in the system if the user chooses forget password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool SetPassword(string password,string username)
        {
            DataAccess access = new DataAccess();
            return access.UpdatePassword(password,username);
           
        }
        
        /// <summary>
        /// method to check if the password and re-entered password have matched or not.
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool MatchPassword(UserInput userObj)
        {
            if (userObj.password.Equals(userObj.confirmPassword))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// method to check if the user has been successfully registered in the system or not.
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool IsRegistered(UserInput userObj ) 
        {
            DataAccess access = new DataAccess();
            if (access.RegisterUser(userObj))
            {
                return true;
            }
            return false;
        } 
    }
}
