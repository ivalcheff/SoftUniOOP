using LoggerLibrary.Appenders.Interfaces;
using LoggerLibrary.Layouts.Interfaces;
using LoggerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout _layout;

        public ConsoleAppender(ILayout layout)
        {
            _layout = layout;
        }

        public LogEntryLevel LogLevel { get; set; } = 0;
        

        public void Append(Message message)
        {
            Console.WriteLine(_layout.Format(message)); 
        }
    }
}
