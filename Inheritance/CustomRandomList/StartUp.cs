namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings = new RandomList(new List<string> { "sahjg", "asjhsa", "kash" });

            Console.WriteLine(strings.RandomString());



        }
    }
}
