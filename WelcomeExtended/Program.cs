using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;
using Welcome.View;
using WelcomeExtended.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserData userData = new UserData();
            User studentUser = new User()
            {
                Names = "student",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };  
            userData.addUser(studentUser);
            User studentUser1 = new User()
            {
                Names = "student1",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };
            userData.addUser(studentUser1);
            User teacherUser = new User()
            {
                Names = "teacher",
                Password = "1234",
                Role = UserRolesEnum.PROFESSOR
            };
            userData.addUser(teacherUser);
            User adminUser = new User()
            {
                Names = "admin",
                Password = "12345",
                Role = UserRolesEnum.ADMIN
            };
            userData.addUser(adminUser);

            string name, password;
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            password = Console.ReadLine();
            if (UserHelper.validateCredentials(userData, name, password))
            {
                User currUser = UserHelper.getUser(userData, name, password);
                Console.WriteLine(UserHelper.ToString(currUser));
            }
        }
    }
}
