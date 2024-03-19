using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    public class Bus : Vehicle
    {
        public const double ConsumptionMod = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double fuelNeeded = (FuelConsumption + ConsumptionMod) * distance;

            if (fuelNeeded < FuelQuantity)
            {
                FuelQuantity -= fuelNeeded;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
        }

        public void DriveEmpty(double distance)
        {
            double fuelNeeded = FuelConsumption * distance;

            if (fuelNeeded <= FuelQuantity)
            {
                FuelQuantity -= fuelNeeded;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
        }
        
    }
}
