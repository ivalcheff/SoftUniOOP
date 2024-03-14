using _1.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    public abstract class Vehicle : IDrivable
    {
		private double _fuelQuantity;
        private double _fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => _fuelQuantity;
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }
                _fuelQuantity = value; 
            }
        }

        public double FuelConsumption
        {
            get => _fuelConsumption;
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption must be a positive number");
                }
                _fuelConsumption = value; 
            }
        }

        public void Drive(double distance)
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

        public virtual void Refuel(double fuel)
        {
            if (fuel < 0)
{
                throw new ArgumentException(message: "Fuel must be a positive number");
            }
            FuelQuantity += fuel;

        }
    }
}
