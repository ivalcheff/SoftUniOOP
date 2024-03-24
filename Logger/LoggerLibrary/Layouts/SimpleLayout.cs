using LoggerLibrary.Layouts.Interfaces;
using LoggerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary.Layouts
{
    public class SimpleLayout : ILayout
    {

        public string Format(Message message)
        {
            return $"{message.DateTime} - {message.LogEntryLevel} - {message.LogMessage}";
        }
    }
}
