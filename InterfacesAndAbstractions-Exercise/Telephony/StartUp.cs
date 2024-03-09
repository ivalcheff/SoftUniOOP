using Telephony.Interfaces;
using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);         

            foreach (string number in numbers)
            {
                if (IsValidPhoneNumber(number))
                {
                    ICaller phone;

                    if (number.Length == 7)
                    {
                        phone = new StationaryPhone();
                    }
                    else
                    {
                        phone = new Smartphone();
                    }

                    phone.Call(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (string site in sites)
            {
                if (IsUrlValid(site))
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Browse(site);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }

        private static bool IsUrlValid(string site)
        {
            return !site.Any(char.IsDigit);
        }

        private static bool IsValidPhoneNumber(string n)
        {
            return n.All(char.IsDigit);
        }
    }
}

/*
0882134215 0882134333 0899213421 0558123 3333123 098765y
http://softuni.bg http://youtube.com http://www.g00gle.com
 
 */
