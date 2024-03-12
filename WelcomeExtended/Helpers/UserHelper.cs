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
        public static int validateCredentials(UserData userData, string name, string password)
        {
            if (name.Equals("")) 
            {
                return 0;
            }
            if (password.Equals(""))
            {
                return 2;
            }
            if (!userData.validateUser(name, password)) 
            {
                return 3;
            }
            return 1;
        }
        public static User getUser(UserData userData, string name, string password)
        { 
            return userData.getUser(name, password);
        }
    }
}
