using LoggerLibrary.Appenders;
using LoggerLibrary.Appenders.Interfaces;
using LoggerLibrary.Layouts;
using LoggerLibrary.Layouts.Interfaces;
using LoggerLibrary.Loggers;
using LoggerLibrary.Loggers.Interfaces;

namespace LoggerLibrary.Factories
{
    public class LoggerFactory
    {
        public ILogger CreateLogger(string type)
        {
            ILayout layout = new SimpleLayout();
            IAppender appender;

            switch (type)
            {
                case "console":
                    appender = new ConsoleAppender(layout);
                    break;
                case "file":
                    appender = new FileAppender(layout);
                    break;
                default:
                    throw new ArgumentException("Invalid appender type.");
            }

            return new Logger(appender);
        }
    }
}
