using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FuelConsumptionMod = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + FuelConsumptionMod)
        {
        }



    }
}
