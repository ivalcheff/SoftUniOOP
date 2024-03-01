using System.Collections.Generic;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            List<Mammal> mammalList = new List<Mammal>();

            mammalList.Add(new Gorilla("Pesho"));
            mammalList.Add(new Bear("Gosho"));

        }
    }
}