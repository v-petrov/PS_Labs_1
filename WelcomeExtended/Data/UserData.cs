using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace WelcomeExtended.Data
{
    internal class UserData
    {
        private List<User> _users;
        private int _nextId;
        public UserData()
        { 
            _users = new List<User>();
            _nextId = 0;
        }
    }
}
