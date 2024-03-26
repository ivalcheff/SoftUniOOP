using System.Reflection;

namespace MethodReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
           RandomGenerator randomGenerator = new RandomGenerator();
           // Console.WriteLine(randomGenerator.GenerateNumber());

            Type type = typeof(RandomGenerator);

            MethodInfo method = type.GetMethod("GenerateNumber");
            int number = (int)method.Invoke(randomGenerator, null);
            Console.WriteLine(number);


            MethodInfo staticMethod = type.GetMethod("GenerateNumberStatic");
            staticMethod.Invoke(null, null);

            MethodInfo parameterMethod = type.GetMethod("GenerateNumberBetween");
            int number2 = (int)parameterMethod.Invoke(randomGenerator, new object[] { 20, 39 });
            Console.WriteLine(number2);

        }
    }

    public class RandomGenerator
    {
        public int GenerateNumber()
        {
            return new Random().Next();
        }

        public static int GenerateNumberStatic()
        {
            Console.WriteLine("Static called");
            return new Random().Next();
        }

        public int GenerateNumberBetween(int from, int to)
        {
            return new Random().Next(from, to);
        }

    }
   
}
