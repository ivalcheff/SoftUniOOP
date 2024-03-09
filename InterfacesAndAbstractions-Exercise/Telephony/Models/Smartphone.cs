using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICaller, IBrowser
    {
        public void Browse(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
