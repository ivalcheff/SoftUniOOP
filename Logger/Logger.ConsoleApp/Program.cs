using LoggerLibrary.Appenders;
using LoggerLibrary.Appenders.Interfaces;
using LoggerLibrary.Factories;
using LoggerLibrary.Layouts;
using LoggerLibrary.Layouts.Interfaces;
using LoggerLibrary.Loggers.Interfaces;
using LoggerLibrary.Models;
using System.Globalization;
//InitializeWithoutFactory();
//ILogger consoleLogger = InitializeWithFactory();

//consoleLogger.Info(DateTime.Now, "It works!");
//consoleLogger.Warning(DateTime.Now, "It does not look good... ");
//consoleLogger.Error(DateTime.Now, "It does not work :(");
//consoleLogger.Critical(DateTime.Now, "It looks even worse now :(");
//consoleLogger.Fatal(DateTime.Now, "Became she what she became");


int n = int.Parse(Console.ReadLine());
List<IAppender> appenders = new List<IAppender>();
for (int i = 0; i < n; i++)
{
    string[] appenderTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string appenderType = appenderTokens[0];
    string layoutType = appenderTokens[1];

    if (appenderTokens.Length > 2)
    {
        string reportLevel = appenderTokens[2];
    }

    ILayout layout = new SimpleLayout();
    switch (layoutType)
    {
        case "SimpleLayout":
            layout = new SimpleLayout();
            break;
        case "XmlLayout":
            layout = new XmlLayout();
            break;
        default:
            Console.WriteLine("Invalid layout.");
            break;
    }

    IAppender appender = new ConsoleAppender(layout);
    switch (appenderType)
    {
        case "ConsoleAppender":
            appender = new ConsoleAppender(layout);
            break;
        case "FileAppender":
            appender = new FileAppender(layout);
            break;
        default:
            Console.WriteLine("No valid appender type.");
            break;
    }

    appenders.Add(appender);
}

ILogger logger = new LoggerLibrary.Loggers.Logger(appenders);

string input;

while ((input = Console.ReadLine()) != "END")
{
    string[] data = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

    switch (data[0])
    {
        case "INFO":
            logger.Info(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
            break;
        case "WARNING":
            logger.Warning(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
            break;
        case "ERROR":
            logger.Error(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
            break;
        case "CRITICAL":
            logger.Critical(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
            break;
        case "FATAL":
            logger.Fatal(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
            break;            
    }
}




void InitializeWithoutFactory()
{
    //instantiate the layouts, which take the string and format it in the desired way
    ILayout simpleLayout = new SimpleLayout();
    ILayout xmlLayout = new XmlLayout();

    //instantiate appenders, which append the formatted message 
    IAppender consoleAppender = new ConsoleAppender(simpleLayout);
    IAppender fileAppender = new FileAppender(xmlLayout);

    //log only entries from Error and higher
    consoleAppender.LogLevel = LogEntryLevel.Error;

    //add different appenders to the logger
    ILogger logger = new LoggerLibrary.Loggers.Logger(fileAppender);
    logger.AddAppender(consoleAppender);
}

ILogger InitializeWithFactory()
{
    var loggerFactory = new LoggerFactory();
    ILogger consoleLogger = loggerFactory.CreateLogger("console");
    ILogger fileLogger = loggerFactory.CreateLogger("file");
    return consoleLogger;
}


/*
2
ConsoleAppender SimpleLayout CRITICAL
FileAppender XmlLayout
INFO|3/26/2015 2:08:11 PM|Everything seems fine
WARNING|3/26/2015 2:22:13 PM|Warning: ping is too high - disconnect imminent
ERROR|3/26/2015 2:32:44 PM|Error parsing request
CRITICAL|3/26/2015 2:38:01 PM|No connection string found in App.config
FATAL|3/26/2015 2:39:19 PM|mscorlib.dll does not respond
END

 */