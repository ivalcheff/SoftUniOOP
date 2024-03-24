using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLibrary.Models
{
    public enum LogEntryLevel
    {
        Info = 0, 
        Warning = 1, 
        Error = 2, 
        Critical = 3, 
        Fatal = 4
    }
}
