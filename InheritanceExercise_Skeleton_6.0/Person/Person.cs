using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private int _age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }  //auto property - когато нямаме custom logic в задаването на стойност
        public virtual int Age   //virtual so we can override in Child 
        { 
            get { return _age; } 
            set   //залагаме къстъм логика в сетъра, за да не може отвън да се сетва age < 0
            { 
                if (value < 0)
                {
                    _age = 0;
                    //throw new ArgumentException("Age cannot be less than 0");
                }
                else
                {
                    _age = value;
                }
            } 
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }

    }
}
