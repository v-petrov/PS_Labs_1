using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

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
        public void addUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }
        public void deleteUser(User user)
        {
            _users.Remove(user);
        }
        public bool validateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Names == name && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool validateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password)
                          .FirstOrDefault() != null ? true : false;
        }
        public bool validateUserLinq(string name, string password)
        {
            var res = from user in _users
                      where user.Names == name && user.Password == password
                      select user.Id;
            return res != null ? true : false;
        }
        public User getUser(string name, string password)
        {
            var res = from user in _users
                      where user.Names == name && user.Password == password
                      select user;
            return res.FirstOrDefault();

        }
        public void assignUserRole(string name, UserRolesEnum userRole)
        {
            var res = from user in _users
                      where user.Names == name
                      select user;
            if (res != null)
            {
                res.First().Role = userRole;
            }
            else 
            {
                Console.WriteLine("No such user found!");
            }
        }

    }
}
