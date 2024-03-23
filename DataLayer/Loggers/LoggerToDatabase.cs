using DataLayer.Database;
using DataLayer.Model;

namespace DataLayer.Loggers
{
    public class LoggerToDatabase
    {
        private readonly DatabaseContext _context;

        public LoggerToDatabase(DatabaseContext context)
        {
            _context = context;
        }

        public void LogMessage(string message)
        {
            var logEntry = new LogEntry { Message = message };
            _context.LogEntries.Add(logEntry);
            _context.SaveChanges();
        }
    }
}
