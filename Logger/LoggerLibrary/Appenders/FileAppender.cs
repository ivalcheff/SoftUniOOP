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
    public class FileAppender : IAppender
    {
        private ILayout _layout;
        public string FilePath { get; set; }
            = $"..\\..\\..\\{DateTime.Now:yyyyMMddhhmm}.txt";

        public FileAppender(ILayout layout)
        {
            _layout = layout;
        }
        public FileAppender(ILayout layout, string filePath) : this(layout)
        {
            FilePath = filePath;

        }

        public LogEntryLevel LogLevel { get; set; } = 0;

        public void Append(Message message)
        {
            string formattedLogEntry = _layout.Format(message);
            try
            {
                File.AppendAllText(FilePath, formattedLogEntry + Environment.NewLine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
