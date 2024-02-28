using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Demo
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public Person Father { get; set; } //recursion
        public Person Mother { get; set; }


        public Person (string firstName)
        {
            FirstName = firstName;
        }

        public Person (string firstName, int age)
            : base(firstName)
        {
            Age = age;
        }

        public string SayHello()
        {
            return $"Hi! My name is {this.FirstName}.";                              
        }
    }
}
