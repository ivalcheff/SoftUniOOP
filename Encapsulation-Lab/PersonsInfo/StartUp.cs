using System.Runtime.CompilerServices;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            Team team = new Team("SoftUni");


            for (int i = 0; i < lines; i++)
            {
                string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var person = new Person(personData[0], personData[1], int.Parse(personData[2]), decimal.Parse(personData[3]));
                team.AddPlayer(person);

                //try
                //{
                //    var person = new Person(personData[0], personData[1], int.Parse(personData[2]), decimal.Parse(personData[3]));
                //    team.AddPlayer(person);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}

/*
5
Brandi Anderson 65
Andrew Williams 57
Newton Holland 27
Andrew Clark 44
Brandi Scott 35
 

5
Andrew Williams 65 2200
Newton Holland 57 3333
Rachelle Nelson 27 600
Brandi Scott 44 666.66
George Miller 35 559.4
20


5
Andrew Williams -6 2200
B Gomez 57 3333
Carolina Richards 27 670
Gilbert H 44 666.66
Joshua Anderson 35 300
20

5
Andrew Williams 20 2200
Newton Holland 57 3333
Rachelle Nelson 27 600
Grigor Dimitrov 25 666.66
Brandi Scott 35 555

 */
