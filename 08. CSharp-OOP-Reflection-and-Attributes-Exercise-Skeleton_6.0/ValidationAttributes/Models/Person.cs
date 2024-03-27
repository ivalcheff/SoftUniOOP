using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(MinAge,MaxAge)]
        public int Age { get; set; }
        public string Address { get; set; }
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

    }
}
