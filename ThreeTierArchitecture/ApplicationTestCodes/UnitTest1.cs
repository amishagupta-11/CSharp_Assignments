using BusinessLayer;
using UserDetails;
namespace ApplicationTestCodes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UsernameExistsTest()
        {
            BAuthentication bAuth = new BAuthentication();
            var userInput = new UserInput()
            { username="suppu" };
            bool test = bAuth.IsUsernameExists(userInput);
            Assert.IsTrue(test, "UserExists");
        }

        [TestMethod]
        public void UsernameNotExistsTest()
        {
            BAuthentication bAuth = new BAuthentication();
            var userInput = new UserInput()
            { username="Amisha" };
            bool test = bAuth.IsUsernameExists(userInput);
            Assert.IsFalse(test, "User does not Exists");
        }
        [TestMethod]
        public void PasswordPatternMatchTest()
        {
            var bAuth = new BAuthentication();
            var userInput = new UserInput()
            {
                password="Amisha#111"
            };
            bool test = bAuth.IsPassword(userInput);
            Assert.IsTrue(test,"password Verified");
        }
        [TestMethod]
        public void PasswordPatternIncorrectTest()
        {
            var bAuth = new BAuthentication();
            var userInput = new UserInput()
            {
                password="teddy"
            };
            bool test = bAuth.IsPassword(userInput);
            Assert.IsFalse(test, "password did not match");
        }
        [TestMethod]
        public void PasswordMatchedTest()
        {
            var bAuth = new BAuthentication();
            var userInput = new UserInput()
            {
                password="Amisha@123"
            };
            var userInputObj = new UserInput()
            {
                confirmPassword="Amisha@123"
            };
            bool test = bAuth.IsPasswordMatch(userInput);
            Assert.IsTrue(test, "Confirmed");
        }
        [TestMethod]
        public void PasswordNotMatchedTest()
        {
           BAuthentication bAuth = new BAuthentication();
            var userInput = new UserInput()
            {
                password="Amisha@1"
            };
            var userInputObj = new UserInput()
            {
                confirmPassword="Amisha@123"
            };
            bool test=bAuth.IsPasswordMatch(userInput);
            Assert.IsFalse(test, "Password Did not match");
        }
        [TestMethod]
        public void UserRegistrationSuccessTest()
        {
            BAuthentication bAuth = new BAuthentication();
            var userInput = new UserInput()
            {
                email="amisha.gupta11@gmail.com",
                username="Amisha13",
                password="Amisha@123"
            };
            bool test=bAuth.RegisteredUser(userInput);
            Assert.IsTrue(test, "User Registered");
        }
        [TestMethod]
        public void LoginDetails_presentTest()
        {
            BAuthentication bAuth = new BAuthentication();
            UserInput userObj = new UserInput();
            userObj.username="Amisha";
            userObj.password="Amisha";
            bool test = bAuth.LoginHere(userObj);
            Assert.IsTrue(test, "Is not null");
        }
        [TestMethod]
        public void LoginDetails_Not_presentTest()
        {
            BAuthentication bAuth = new BAuthentication();
            UserInput userObj = new UserInput();
            userObj.username=" ";
            userObj.password=" ";
            bool test = bAuth.LoginHere(userObj);
            Assert.IsTrue(test, "Is null");
        }
        [TestMethod]
        public void LoginSuccessTest()
        {
            BAuthentication bAuth = new BAuthentication();
            UserInput userObj = new UserInput();
            userObj.username="Amisha_18";
            userObj.password="Amisha@145";
            bool test = bAuth.LoginSuccess(userObj);
            Assert.IsTrue(test, "User Logged in Successfully.");
        }
        [TestMethod]
        public void ValidEmailTest()
        {
            BAuthentication bAuth = new BAuthentication();  
            UserInput userInput = new UserInput();
            userInput.email="anusha@gmail.com";
            bool test = bAuth.IsValidEmail(userInput);
            Assert.IsTrue(test, "valid email");
        }
        [TestMethod]
        public void InValidEmailTest()
        {
            BAuthentication bAuth = new BAuthentication();
            UserInput userInput = new UserInput();
            userInput.email="joker@gmail.com";
            bool test = bAuth.IsValidEmail(userInput);
            Assert.IsFalse(test, "Invalid email");
        }
        [TestMethod]
        public void ValidUsernameTest()
        {
            BAuthentication bAuth = new BAuthentication();
            UserInput userInput = new UserInput();
            userInput.username="vedika_23";
            bool test = bAuth.IsValidUsername(userInput);
            Assert.IsTrue(test, "valid username");
        }
        [TestMethod]
        public void InValidUsernameTest()
        {
            BAuthentication bAuth = new BAuthentication();
            UserInput userInput = new UserInput();
            userInput.username="vedika_";
            bool test = bAuth.IsValidUsername(userInput);
            Assert.IsFalse(test, "Invalid username");
        }
        [TestMethod]
        public void PasswordUpdateTest()
        {
            BAuthentication bAuth = new BAuthentication();
            UserInput user= new UserInput();
            user.password="Amisha@145";
            user.username="Amisha_18";
            bool test = bAuth.IsPasswordUpdate(user.password,user.username);
            Assert.IsTrue(test, "Password updated");
        }



    }
}