using CommandPattern.Commands;

namespace CommandPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            while (true)
            {
                calculator.PrintHistory();

                string @operator = Console.ReadLine();
                int value = int.Parse(Console.ReadLine());


                ICommand command = null;

                if (@operator == "+")
                {
                    command = new PlusCommand(value);
                }

                if (@operator == "-")
                {
                    command = new MinusCommand(value);
                }

                if (@operator == "/")
                {
                    command = new DivideCommand(value);
                }

                if (@operator == "*")
                {
                    command = new MultiplyCommand(value);
                }

                if (@operator == "u")
                {
                    calculator.Undo(value);
                }


                if (command != null)
                {
                    calculator.ExecuteCommand(command);
                }
                calculator.ExecuteCommand(command);

                Console.Clear();

            }
        }
    }
}
