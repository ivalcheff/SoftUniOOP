using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> bag;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;

            bag = new List<Product>();
        }

        public List<Product> Bag => bag;  //so we can print the contents of the private field bag 
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(Name)} cannot be empty");
                }

                name = value;
            }
        }
        public double Money
        {
            get => money;
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Money cannot be negative");
                }
                money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                bag.Add(product);
            }
            else
            {
                throw new ArgumentException($"{Name} can't afford {product.Name}");
                
            }
            
        }

    }
}
