using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Commands;

namespace CommandPattern
{
    public class Calculator
    {
        private List<ICommand> commands;

        public Calculator()
        {
            commands = new List<ICommand>();
        }

        public decimal Result { get; set; }

        public void ExecuteCommand(ICommand command)
        {
            Result = command.Execute(Result);
            commands.Add(command);
        }

        public void Undo(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Result = commands[commands.Count - 1].UnExecute(Result);
                commands.RemoveAt(commands.Count - 1);
            }
        }

        public void PrintHistory()
        {
            Console.Write("0 ");
            foreach (var command in commands)
            {
                Console.Write($"{command.Operator} {command.Value} ");
            }
            Console.WriteLine($"= {Result}");
        }

    }
}
