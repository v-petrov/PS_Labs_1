using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;
using Welcome.View;
using WelcomeExtended.Others;
namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var user = new User
                {
                    Names = "John Smith",
                    Password = "password123",
                    Role = UserRolesEnum.STUDENT
                };

                var viewModel = new UserViewModel(user);

                var view = new UserView(viewModel);
                view.display();
                view.displayError();
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}
