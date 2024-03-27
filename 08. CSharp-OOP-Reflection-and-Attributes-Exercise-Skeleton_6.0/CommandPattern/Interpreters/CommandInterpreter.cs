using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Interpreters
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] parts = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = $"{parts[0]}Command";
            var commandArgs = parts.Skip(1).ToArray();

            //взимаме сегашното Assembly и в него ще търсим необходимите типове
            var assembly = Assembly.GetEntryAssembly();

            //намираме типа със същото име като подадената команда
            Type type = assembly?.GetTypes().FirstOrDefault(t => t.Name == command);

            if (type ==  null)
            {
                throw new ArgumentException("Invalid type");
            }

            //правим инстанция на типа, за да можем да му ползваме метода
            var instance = (ICommand)Activator.CreateInstance(type) ;
            return instance?.Execute(commandArgs);        
        }
    }
}
