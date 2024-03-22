using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;
        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public void display()
        {
            Console.WriteLine("Welcome:\n" +
                "User: " + _viewModel.user.Names +
                "\n" + "Role: " + _viewModel.user.Role +
                "\n" + "Faculty Number: " + _viewModel.user.FacultyNumber +
                "\n" + "Email: " + _viewModel.user.Email);
        }
        public void displayError()
        {
            throw new Exception("Random error");
        }
    }
}
