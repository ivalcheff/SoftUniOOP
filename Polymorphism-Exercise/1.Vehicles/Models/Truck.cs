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
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + FuelConsumptionMod)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(FuelLeak * fuel);
        }
    }
}
