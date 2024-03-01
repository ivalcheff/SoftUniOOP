using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Child : Person
    {
        public Child (string name, int age)    //reuse the base ctor to instantiate a child  
            : base (name, age)
        {

        }

        public override int Age 
        {
            get => base.Age; 
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Child cannot be older than 15");                
                }
                else
                {
                    base.Age = value;
                }
            }
        }

    }
}
