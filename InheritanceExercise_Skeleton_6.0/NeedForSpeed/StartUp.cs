using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car bmw = new(320, 63.8);

            Console.WriteLine(bmw.FuelConsumption);

            RaceMotorcycle honda = new(250, 20);

            Console.WriteLine(honda.FuelConsumption);
        }
    }
}
