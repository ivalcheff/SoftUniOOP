namespace ExplicitInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Citizen citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));

                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}

/*
GeorgeSmith Bulgaria 33
EricAnderson GreatBritain 28
PeterArmstrong USA 19
End
 */
