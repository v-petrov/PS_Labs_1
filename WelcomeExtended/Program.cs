using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;
using Welcome.View;
using WelcomeExtended.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;
namespace WelcomeExtended
{
    internal class Program
    {
        private static int eventId = 0;
        static void Main(string[] args)
        {
            ILogger successfulLogger = new FileLogger(@"E:\VS\PS_43_Vasil\WelcomeExtended\Resources\successfullyLogInUsers.txt");
            ILogger notSuccessfulLogger = new FileLogger(@"E:\VS\PS_43_Vasil\WelcomeExtended\Resources\notSuccessfullyLogInUsers.txt");
            UserData userData = new();
            User studentUser = new()
            {
                Names = "student",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };  
            userData.addUser(studentUser);
            User studentUser1 = new()
            {
                Names = "student1",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };
            userData.addUser(studentUser1);
            User teacherUser = new()
            {
                Names = "teacher",
                Password = "1234",
                Role = UserRolesEnum.PROFESSOR
            };
            userData.addUser(teacherUser);
            User adminUser = new()
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
            password = User.HashPassword(password);
            int res = UserHelper.validateCredentials(userData, name, password);
            switch (res)
            {
                case 1:
                    User currUser = UserHelper.getUser(userData, name, password);
                    Console.WriteLine(UserHelper.ToString(currUser));
                    successfulLogger.Log(LogLevel.Information, new EventId(eventId++), $"User {name} logged in successfully.", null, (state, exception) => state.ToString());
                    break;
                case 0:
                    LoggerHelper.notSuccessfulLogin(notSuccessfulLogger, eventId++, "The name cannot be empty!");
                    break;
                case 2:
                    LoggerHelper.notSuccessfulLogin(notSuccessfulLogger, eventId++, "The password cannot be empty!");
                    break;
                case 3:
                    LoggerHelper.notSuccessfulLogin(notSuccessfulLogger, eventId++, "No such user found!");
                    break;

            }
        }
    }
}
