using LoggerLibrary.Layouts.Interfaces;
using LoggerLibrary.Models;
using System.Xml.Linq;

namespace LoggerLibrary.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format(Message message)
        {
            XElement logEntry = new XElement("log",
                new XElement("date", message.DateTime),
                new XElement("level", message.LogEntryLevel),
                new XElement("message", message.LogMessage));
            return logEntry.ToString();
        }
    }
}
