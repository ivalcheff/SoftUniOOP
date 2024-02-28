using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Demo
{
    public class Student : Person
    {

        public Student(string firstName)
            :base(firstName)
        {
            School = "Aleko Konstantinov";
        }

        public Student (string firstName, int age, string school, decimal tax)
            :base(firstName, age)
        {
            School = school;
            Tax = tax;
        }

        public string School { get; set; }
        public decimal Tax { get; set; }
    }
}
