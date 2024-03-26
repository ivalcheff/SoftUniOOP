using System.Reflection;

namespace _00.DemoFields
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Getting information about fields and properties and their values, even if they are private

            Type type = typeof(Student);

            FieldInfo field = type.GetField("age");
            PropertyInfo property = type.GetProperty("Name");

            Student gosho = new Student();
            Student pesho = new Student();

            gosho.age = 10;
            gosho.Name = "Gosho";
            pesho.age = 15;

            Console.WriteLine($"{property.GetValue(gosho)} - {field.GetValue(gosho)}");
            Console.WriteLine(field.GetValue(pesho));

            field.SetValue(gosho, 17);

            Console.WriteLine(field.GetValue(gosho));

            //this is how we get all the fields of an object
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            FieldInfo[] fields2 = type.GetFields((BindingFlags)60);  //gets everything
        }
    }

    class Student
    {
        public int age;

        public string Name { get; set; }

       
    }
}
