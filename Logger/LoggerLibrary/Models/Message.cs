using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary.Models
{
    public class Message
    {
        public Message(DateTime dateTime, LogEntryLevel logEntryLevel, string logMessage)
        {
            DateTime = dateTime;
            LogEntryLevel = logEntryLevel;
            LogMessage = logMessage;
        }

        public DateTime DateTime { get; set; }
        public LogEntryLevel LogEntryLevel { get; set; }

        public string LogMessage { get; set; }
    }
}
