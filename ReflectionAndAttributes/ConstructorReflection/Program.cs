using System.Reflection;

namespace ConstructorReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Student);
            ConstructorInfo[] constructors = type.GetConstructors((BindingFlags)60);

            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.Name);
                ParameterInfo[] parameters = constructor.GetParameters();
                Console.WriteLine(parameters.Length);

                foreach (ParameterInfo parameter in parameters)
                {
                    Console.WriteLine($"{parameter.ParameterType.Name} {parameter.Name}");
                }
            }
        }
    }

    class Student
    {
        public Student()
        {
            
        }
        public Student(string name)
        {
            Name = name;
        }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
