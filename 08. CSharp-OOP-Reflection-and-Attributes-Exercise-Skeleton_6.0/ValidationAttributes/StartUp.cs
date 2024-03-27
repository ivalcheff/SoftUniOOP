using System;
using ValidationAttributes.Models;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "Gosho",
                 25
             );

            var person2 = new Person
                (
                    null,
                    -1
                );

            bool isValidEntity = Validator.IsValid(person);
            bool isValidEntity2 = Validator.IsValid(person2);

            Console.WriteLine(isValidEntity);
            Console.WriteLine(isValidEntity2);
        }
    }
}
