using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionMod = 1.6;
        private const double FuelLeak = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + FuelConsumptionMod, tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            if (FuelQuantity + fuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            base.Refuel(FuelLeak * fuel);
        }
    }
}
