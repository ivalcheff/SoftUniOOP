using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System.Linq.Expressions;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //BorderControl();

            List<IBirthable> birthables = new List<IBirthable>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Citizen")
                {
                    IBirthable a = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);               
                    birthables.Add(a);
                }
                else if (tokens[0] == "Pet")
                {
                    IBirthable b = new Pet(tokens[1], tokens[2]);
                    birthables.Add(b);
                }
            }

            string year = Console.ReadLine();

            foreach (var b in  birthables)
            {
                if (b.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(b.Birthdate);
                }
            }

        }

        private static void BorderControl()
        {
            List<IIdentifiable> visitors = new List<IIdentifiable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IIdentifiable visitor;

                if (tokens.Length == 2)
                {
                    visitor = new Robot(tokens[0], tokens[1]);
                }
                else
                {
                    visitor = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                }

                visitors.Add(visitor);
            }

            string fakeIdEnd = Console.ReadLine();

            foreach (var visitor in visitors)
            {
                if (visitor.Id.EndsWith(fakeIdEnd))
                {
                    Console.WriteLine(visitor.Id);
                }

            }
        }
    }
}

/*
INPUT 05

Citizen Peter 22 9010101122 10/10/1990
Pet Sharo 13/11/2005
Robot MK-13 558833251
End
1990

Citizen Stam 16 0041018380 01/01/2000
Robot MK-10 12345678
Robot PP-09 00000001
Pet Topcho 24/12/2000
Pet Rex 12/06/2002
End
2000

Robot VV-XYZ 11213141
Citizen Corso 35 7903210713 21/03/1979
Citizen Kane 40 7409073566 07/09/1974
End
1975


INPUT 04
Peter 22 9010101122
MK-13 558833251
MK-12 33283122
End
122

Teo 31 7801211340
Peter 29 8007181534
IV-228 999999
Sam 54 3401018380
KKK-666 80808080
End
340

George 954614
Ron 124610
VI-228 999999
Mike 13 7604128614
Peter 90 5602142414
T500 131313130
End
14
 */
