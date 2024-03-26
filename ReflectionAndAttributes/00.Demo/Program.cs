using System.Reflection;
using System.Runtime.InteropServices;

namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            meta data is data about data
            reflection makes it possible to view meta data for our own code
            Type is the main class in reflection

            Metadata can be obtained at:
                Compile time (if you know it's name)
                    Type myType = typeof(ClassName);
                Runtime, if the name is not known during compiling
                    Type myType = Type.GetType("Namespace.ClassName");
                Get the type of an instance of an onject
                    obj.GetType();           
                    EVERY OBJECT HAS .GetType(); method, which returns a Type object 
             */

            //Type is an abstraction for common metadata for every class

            Console.WriteLine("Getting the class name and info");

            Type type = typeof(DateTime);

            Console.WriteLine($"Name {type.Name}");
            Console.WriteLine($"FullName {type.FullName}");
            Console.WriteLine($"Assembly {type.Assembly}");
            Console.WriteLine($"IsArray {type.IsArray}");
            Console.WriteLine($"IsPublic {type.IsPublic}");
            Console.WriteLine($"IsGenericType {type.IsGenericType}");
            Console.WriteLine($"IsAbstract {type.IsAbstract}");
            Console.WriteLine($"IsClass {type.IsClass}");
            Console.WriteLine($"IsSealed {type.IsSealed}");

            Console.WriteLine();
            Console.WriteLine();

            Type type1 = typeof(int[]);

            Console.WriteLine($"Name {type1.Name}");
            Console.WriteLine($"FullName {type1.FullName}");
            Console.WriteLine($"Assembly {type1.Assembly}");
            Console.WriteLine($"IsArray {type1.IsArray}");
            Console.WriteLine($"IsPublic {type1.IsPublic}");
            Console.WriteLine($"IsGenericType {type1.IsGenericType}");
            Console.WriteLine($"IsAbstract {type1.IsAbstract}");
            Console.WriteLine($"IsClass {type1.IsClass}");
            Console.WriteLine($"IsSealed {type1.IsSealed}");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Getting the base class and interfaces");

            Type[] interfaces = typeof(DateTime).GetInterfaces();

            foreach (Type interfaceType in interfaces)
            {
                PrintTypeInformation(interfaceType);
            }


            Console.WriteLine();
            Console.WriteLine("Reflecting fields");

            FieldInfo field = type.GetField("name");
            FieldInfo[] publicFields = type.GetFields();


            void PrintTypeInformation(Type type)
            {
                Console.WriteLine(type.Name);
            }





        }
    }
}
