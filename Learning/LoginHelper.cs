using System;

namespace Learning
{
    public class LoginHelper
    {
        private readonly UserCreator userCreator_;

        public LoginHelper(UserCreator userCreator)
        {
            userCreator_ = userCreator;
        }

        public string Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName.Trim()))
            {
                throw new ArgumentException("Cannot be empty", userName);
            }

            if (string.IsNullOrEmpty(password.Trim()))
            {
                throw new ArgumentException("Cannot be empty", password);
            }

            if (userCreator_.Users.ContainsKey(userName))
            {
                if (userCreator_.Users[userName].Equals(password))
                {
                    return "Login Successful";
                }
            }
            return "Login Failed";
        }
    }
}