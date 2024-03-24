using LoggerLibrary.Models;

namespace LoggerLibrary.Layouts.Interfaces
{
    public interface ILayout
    {
        string Format(Message message);
    }
}
