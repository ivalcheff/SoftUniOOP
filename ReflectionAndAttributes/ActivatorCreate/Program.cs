namespace ActivatorCreate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(DateTime);

            DateTime time = (DateTime)Activator.CreateInstance(type, new object[] {2024,3,26});

            Console.WriteLine(time);
        }
    }
}
