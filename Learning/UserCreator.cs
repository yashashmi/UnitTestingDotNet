using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Learning
{
    public class UserCreator
    {
        public UserCreator()
        {
            Users = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Users { get; set; }

        public string CreateUser(string userName, string password)
        {
            var isLettersOnly = Regex.IsMatch(userName, @"^[a-zA-Z]+$");
            var passwordLength = password.Length;
            var atLeastOneChar = password.Any(p => char.IsLetter(p));
            var atLeastOneDigit = password.Any(p => char.IsDigit(p));
            
            if (!isLettersOnly || passwordLength < 6 || !atLeastOneChar || !atLeastOneDigit)
            {
                return "User creation failed";
            }

            Users.Add(userName, password);
            
            return "User created successfully";
        }
    }
}