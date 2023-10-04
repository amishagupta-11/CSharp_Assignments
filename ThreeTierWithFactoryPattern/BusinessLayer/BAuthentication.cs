using System;
using UserDetails;

namespace BusinessLayer
{
    /// <summary>
    /// Specific class for all registration,login and forget password implementations.
    /// </summary>
    public class BAuthentication
    {
        /// <summary>
        /// specific method for checking if the new username entered is available or not.
        /// </summary>
        public bool IsUsernameExists(UserInput userObj)
        {
            
            BValidation bValid = new BValidation();            
            return bValid.IsUsername(userObj);
        }
        /// <summary>
        /// method to check if password is in desired format or not.
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool IsPassword(UserInput userObj)
        {
            
            BValidation bValid = new BValidation();
            bool passCheck = bValid.IsPasswordValid(userObj);
            if (passCheck)
            {
                return true;

            }
            return false;
        }
        /// <summary>
        /// method to find if the passwords entered will match or not.
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool IsPasswordMatch(UserInput userObj)
        {
            
            BValidation bValid = new BValidation();
            return bValid.IsPasswordValid(userObj);
            
        }
        /// <summary>
        /// method to authenticate the user details for registration 
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool RegisteredUser(UserInput userObj)
        {
            BValidation bValid = new BValidation();
            if (bValid.IsRegistered(userObj))
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        /// <summary>
        /// Specific method for user login into the system.
        /// </summary>
        public bool LoginHere(UserInput userObj)
        {
            BValidation validObj = new BValidation();
            //method call to verify the details of user 
            if (validObj.IsUserValid(userObj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// method to verify if the user has successfully logged in or not
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool LoginSuccess(UserInput userObj)
        {
            BValidation validObj = new BValidation();
            if (validObj.Validate(userObj))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Specific method validate email address of user.
        /// </summary>
        public bool IsValidEmail(UserInput userObj)
        {
           
            BValidation validationObj = new BValidation();
            if (validationObj.IsEmail(userObj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// method to validate username of the user 
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool IsValidUsername(UserInput userObj)
        {            
            BValidation validationObj = new BValidation();
            if (validationObj.IsUsername(userObj))
            {
                return true;
            }
            else
            {
                return false;
                
            }
        }
        /// <summary>
        /// method to match passwords entered by the system .
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool IsPasswordSame(UserInput userObj)
        {
           
            BValidation validationObj = new BValidation();

            if (validationObj.IsPasswordValid(userObj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// method to pass the details to update password in the system.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsPasswordUpdate(string password,string username) 
        {
            BValidation validationObj = new BValidation();
            return validationObj.SetPassword(password,username);
                           
        }            
        
    }
}