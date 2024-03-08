using System.Xml.Linq;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            char[] delims = new[] { ';', '=' };

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            var peopleData = Console.ReadLine().Split(delims, StringSplitOptions.RemoveEmptyEntries);
            var productData = Console.ReadLine().Split(delims, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < peopleData.Length; i+=2)
                {
                    people.Add(new Person (peopleData[i], double.Parse(peopleData[i+1])));
                }

                for (int i = 0; i < productData.Length; i += 2)
                {
                    products.Add(new Product(productData[i], double.Parse(productData[i + 1])));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }         

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var person = people.Find(p => p.Name == data[0]);
                var product = products.Find(pr  => pr.Name == data[1]);
               
                try
                {
                    if (person != null && product != null)
                    {
                        person.BuyProduct(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            foreach (var person in people)
            {
                Console.Write($"{person.Name} - ");

                if (person.Bag.Count == 00)
                {
                    Console.WriteLine("Nothing bought");
                    break;
                }
                else
                {
                    Console.WriteLine(string.Join(", ", person.Bag.Select(item => item.Name)));
                }


            }
        }
    }
}

/*
Peter=11;George=4
Bread=10;Milk=2;
Peter Bread
George Milk
George Milk
Peter Milk
END

Maria=0
Coffee=2
Maria Coffee
END

John=-3
Peppers=1;Tomatoes=2;Cheese=3
John Peppers
John Tomatoes
John Cheese
END

 */
