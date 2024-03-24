using DataLayer.Database;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                /*context.Database.EnsureDeleted();*/
                context.Database.EnsureCreated();

                DatabaseMenu.Menu();
                var loggers = context.LogEntries.ToList();
                foreach (var log in loggers)
                {
                    Console.WriteLine($"Logger: [{log.Id}], [{log.Message}], [{log.CreatedAt}]");
                }
            }
        }
    }
}
