namespace AuthorProblem
{
    public class StartUp
    {
        [Author("Pencho")]
        public static void Main()
        {
            new Tracker().PrintMethodsByAuthor();
        }


        [Author("Ivan")]
        [Author("Dragan")]

        public void NewMetod()
        {
            Console.WriteLine("Аз правя нещо");
        }
    }
}