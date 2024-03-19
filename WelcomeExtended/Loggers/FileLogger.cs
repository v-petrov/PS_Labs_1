﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    internal class FileLogger : ILogger
    {
        private readonly string _fileName;
        public FileLogger(string fileName)
        { 
            _fileName = fileName; 
        }
        public IDisposable? BeginScope<Tstate>(Tstate state) where Tstate : notnull
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) 
        {
            string logMessage = formatter(state, exception);
            using (StreamWriter writer = File.AppendText(_fileName))
            {
                writer.WriteLine($"{DateTime.Now} [{logLevel}] {logMessage}");               
            }
        }
    }
}
