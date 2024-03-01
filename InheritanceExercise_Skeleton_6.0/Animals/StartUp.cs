using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType;

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (animalType == "Dog")
                    {
                        var dog = new Dog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        Console.WriteLine(dog);
                    }
                    else if (animalType == "Frog")
                    {
                        var frog = new Frog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        Console.WriteLine(frog);
                    }
                    else if (animalType == "Cat")
                    {
                        var kitty = new Cat(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        Console.WriteLine(kitty);

                    }
                    else if ( animalType == "Kitten")
                    {
                        var catty = new Kitten(animalData[0], int.Parse(animalData[1]));
                        Console.WriteLine(catty);

                    }
                    else if (animalType == "Tomcat")
                    {
                        var kotio = new Tomcat(animalData[0], int.Parse(animalData[1]));
                        Console.WriteLine(kotio);
                    }
                }
                catch (ArgumentException ae)  //that's the argument exception from Animal
                {
                    Console.WriteLine(ae.Message);
                    //when you catch an exception with try-catch,
                    //the console prints the message AND CONTINUES RUNNING
                }

            
            
            }

        }
    }
}

/*
Cat
Tom 12 Male
Dog
Buddy 132 Male
Beast!
 */