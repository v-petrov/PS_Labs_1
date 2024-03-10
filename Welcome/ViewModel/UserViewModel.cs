using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;
        public UserViewModel(User user)
        {
            _user = user; 
        }
        public User user 
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
