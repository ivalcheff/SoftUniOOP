namespace _1.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new Exception("Invalid number.");
                }
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
