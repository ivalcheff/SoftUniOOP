using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> caughtFish;
        private double competitionPoints;
        private bool hasHealthIssues;

        public Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            caughtFish = new List<string>();
            competitionPoints = 0;
            hasHealthIssues = false;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                this.name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set    //so it can be set by the Children
            {
                oxygenLevel = Math.Max(value, 0);

            }
        }

        public IReadOnlyCollection<string> Catch
        {
            get => caughtFish.AsReadOnly(); 

        }

        public double CompetitionPoints
        {
            get => Math.Round(competitionPoints, 1);
        }

        public bool HasHealthIssues
        {
            get => hasHealthIssues;
            private set { hasHealthIssues = value; }
        }


        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            caughtFish.Add(fish.Name);
            competitionPoints += Math.Round(fish.Points, 1, MidpointRounding.AwayFromZero);
        }

        public abstract void Miss(int TimeToCatch);
        

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }

        public abstract void RenewOxy();


        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {caughtFish.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
