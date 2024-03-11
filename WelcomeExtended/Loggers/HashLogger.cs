using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    internal class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;
        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }
        public IDisposable? BeginScope<Tstate>(Tstate state) where Tstate : notnull
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        public void Log<Tstate>(LogLevel logLevel, EventId eventId, Tstate state, Exception? exception, Func<Tstate, Exception?, string> formatter)
        {
            var messagae = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }
            Console.WriteLine("- LOGGER -");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[eventId.Id] = messagae;
        }
        public void printAllLogers()
        {
            foreach (var log in _logMessages) 
            {
                Console.WriteLine($"Log ID: {log.Key}, Message: {log.Value}");
            }
        }
        public void printLogMessageByEventId(int eventId) 
        {
            foreach (var log in _logMessages) 
            {
                if (log.Key == eventId) 
                {
                    Console.WriteLine($"Log ID: {log.Key}, Message: {log.Value}");
                }
            }
        }
        public bool deleteLogMessageByEventId(int eventId)
        {
            return _logMessages.TryRemove(eventId, out _);
        }
        
    }
}
