using System;
using UserDetails;

namespace DataLayer
{
    public interface IDataAccess
    {
        public bool UpdatePassword(string password,string username);
        public bool Verify(UserInput userObj);
        public bool RegisterUser(UserInput userObj);
        public bool LoginUser(string name,string password);
        public bool validEmail(UserInput userObj);
    }
}
