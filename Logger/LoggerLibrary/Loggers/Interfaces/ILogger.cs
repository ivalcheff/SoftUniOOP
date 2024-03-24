using LoggerLibrary.Appenders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary.Loggers.Interfaces
{
    public interface ILogger
    {
        public void Info(DateTime dateTime, string message);
        public void Warning(DateTime dateTime, string message);
        public void Error(DateTime dateTime, string message);
        public void Critical(DateTime dateTime, string message);
        public void Fatal (DateTime dateTime, string message);
        public void AddAppender(IAppender appender);
    }
}
