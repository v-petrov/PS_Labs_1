using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Loggers;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Helpers
{
    internal static class LoggerHelper
    {
        public static ILogger GetLogger(string categoryName)
        { 
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new LoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }
        public static void notSuccessfulLogin(ILogger log, int eventId, string message) 
        {
            log.Log(LogLevel.Error, new EventId(eventId++), message, null, (state, exception) => state.ToString());
        }
    }
}
