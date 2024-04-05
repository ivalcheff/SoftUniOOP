using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string _name;
        private int _stamina;
        private List<string> _conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            _conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                this._name = value;
            }
        }

        public int Stamina
        {
            get => _stamina;
            protected set
            {
                if (value < 0) 
                {
                    value = 0;
                }
                else if (value > 10)
                {
                    value = 10;
                }
                this._stamina = value;
            }

        }
        public IReadOnlyCollection<string> ConqueredPeaks { get => _conqueredPeaks; }


        public void Climb(IPeak peak)
        {
            if (!ConqueredPeaks.Contains(peak.Name))
            {
                _conqueredPeaks.Add(peak.Name);
            }

            if (peak.DifficultyLevel == "Extreme")
            {
                Stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                Stamina -= 4;
            }
            else
            {
                Stamina -= 2;
            }

            if (Stamina < 0)
            {
                Stamina = 0;
            }

        }


        public abstract void Rest(int daysCount);
      

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");

            if (this._conqueredPeaks != null)
            {
                sb.AppendLine($"Peaks conquered: {_conqueredPeaks.Count}");
            }
            else
            {
                sb.AppendLine($"Peaks conquered: no peaks conquered");
            }
            
            return sb.ToString().Trim();
        }
    }
}
