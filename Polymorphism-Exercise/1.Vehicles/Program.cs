using _1.Vehicles.Models;
using System.Reflection;

namespace _1.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));

            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3]));

            string[] busTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                try
                {
                    string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (command[0] == "Drive")
                    {

                        if (command[1] == "Car")
                        {
                            car.Drive(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Drive(double.Parse(command[2]));
                        }
                        else if (command[1] == "Bus")
                        {
                            bus.Drive(double.Parse(command[2]));
                        }
                    }
                    else if (command[0] =="Refuel")
                    {
                        if (command[1] == "Car")
                        {
                            car.Refuel(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(command[2]));
                        }
                        else if (command[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(command[2]));
                        }
                    }
                    else if (command[0] == "DriveEmpty")
                    {
                        bus.DriveEmpty(double.Parse(command[2]));
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }             
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}

/*
Car 15 0.3
Truck 100 0.9
4
Drive Car 9
Drive Car 30
Refuel Car 50
Drive Truck 10


Car 30 0.04 70
Truck 100 0.5 300
Bus 40 0.3 150
8
Refuel Car -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100
Refuel Truck 1000
 */
