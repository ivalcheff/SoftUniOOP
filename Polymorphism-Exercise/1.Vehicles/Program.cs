using _1.Vehicles.Models;

namespace _1.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]));

            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

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
                        else
                        {
                            truck.Drive(double.Parse(command[2]));
                        }
                    }
                    else
                    {
                        if (command[1] == "Car")
                        {
                            car.Refuel(double.Parse(command[2]));
                        }
                        else
                        {
                            truck.Refuel(double.Parse(command[2]));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }             
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
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
 */
