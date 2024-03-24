using LoggerLibrary.Appenders.Interfaces;
using LoggerLibrary.Loggers.Interfaces;
using LoggerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary.Loggers
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> _appenders = new List<IAppender>();

        public Logger(IAppender appender)
        {           
            _appenders.Add(appender);
        }

        public Logger(List<IAppender> appenders)
        {
            _appenders = appenders;
        }

        public void AddAppender(IAppender appender)
        {
            _appenders.Add(appender);
        }

        public void Info(DateTime dateTime, string logMessage)
        {
           Log(new Message(dateTime, LogEntryLevel.Info, logMessage)); 
        }

        public void Warning(DateTime dateTime, string logMessage)
        {
           Log(new Message(dateTime, LogEntryLevel.Warning, logMessage));        
        }
        public void Error(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Error, logMessage));
        }
        public void Critical(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Critical, logMessage));           
        }
        public void Fatal(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Fatal, logMessage));
        }

        private void Log(Message message)
        {
            foreach (IAppender appender in _appenders)
            {
                if (message.LogEntryLevel >= appender.LogLevel)
                {
                    appender.Append(message);
                }
            }
        }           
    }
}
