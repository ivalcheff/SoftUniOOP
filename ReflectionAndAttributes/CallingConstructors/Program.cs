using CallingConstructors;
using System.Reflection;

Type type = typeof(Student);
ConstructorInfo constructor = type.GetConstructors((BindingFlags)60)[0];

Student student = (Student)constructor.Invoke(new object[] { "Mylo", 4 });

namespace CallingConstructors
{
    class Student
    {

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
