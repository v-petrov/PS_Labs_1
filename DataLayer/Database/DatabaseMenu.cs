using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Loggers;
using DataLayer.Model;

namespace DataLayer.Database
{
    public static class DatabaseMenu
    {
        public static void Menu() 
        {
            using (var context = new DatabaseContext())
            {
                var logger = new LoggerToDatabase(context);
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("1. Get all users");
                    Console.WriteLine("2. Add new user");
                    Console.WriteLine("3. Delete user");
                    Console.WriteLine("4. Exit");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            GetAllUsers(context, logger);
                            break;
                        case "2":
                            AddUser(context, logger);
                            break;
                        case "3":
                            DeleteUser(context, logger);
                            break;
                        case "4":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            static void GetAllUsers(DatabaseContext context, LoggerToDatabase logger)
            {
                var users = context.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"Name: {user.Names}, Role: {user.Role}");
                }
                logger.LogMessage("All users gotten!");
            }

            static void AddUser(DatabaseContext context, LoggerToDatabase logger)
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();

                var user = new DatabaseUser { Names = name, Password = password };
                context.Users.Add(user);
                context.SaveChanges();

                Console.WriteLine("User has been added successfully.");
                logger.LogMessage($"The user has been added: {name}");
            }

            static void DeleteUser(DatabaseContext context, LoggerToDatabase logger)
            {
                Console.WriteLine("Enter the name of the user to delete:");
                string name = Console.ReadLine();

                var user = context.Users.FirstOrDefault(u => u.Names == name);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    Console.WriteLine("The user has been deleted successfully.");
                    logger.LogMessage($"The user has been deleted successfully: {name}");
                }
                else
                {
                    Console.WriteLine("No user found with that name.");
                    logger.LogMessage($"The user: {name} couldn't be found!");
                }
            }
        }
    }
}
