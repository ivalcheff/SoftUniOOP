using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        private string _name;
        private List<Person> _firstTeam;
        private List<Person> _reserveTeam;

        public Team(string name)
        {
            _name = name;
            _firstTeam = new List<Person>();
            _reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam => _firstTeam.AsReadOnly();
        public IReadOnlyCollection<Person> ReserveTeam => _reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            { 
                _firstTeam.Add(person); 
            }
            else
            {
                _reserveTeam.Add(person);
            }

            
        }
    }
}
