namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new();

            Console.WriteLine(stack.IsEmpty());
            stack.AddRange(new string[] {"asfd", "adsa", "mfmf", "aihjol"});
            Console.WriteLine(stack.IsEmpty());

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
                
        }
    }
}
