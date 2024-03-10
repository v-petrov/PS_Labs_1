using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    internal static class UserHelper
    {
        public static string ToString(this User user)
        {
            return $"User Details:\nName: {user.Names}\nPassword: {user.Password}\nRole: {user.Role}\nId: {user.Id}";
        }
        public static bool validateCredentials(UserData userData, string name, string password)
        {
            if (name.Equals("")) 
            {
                Console.WriteLine("The name cannot be empty!");
                return false;
            }
            if (password.Equals(""))
            {
                Console.WriteLine("The password cannot be empty!");
                return false;
            }
            if (!userData.validateUser(name, password)) 
            {
                Console.WriteLine("No such user found!");
                return false;
            }
            return true;
        }
        public static User getUser(UserData userData, string name, string password)
        { 
            return userData.getUser(name, password);
        }
    }
}
