using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fish;
        private string[] diverTypes = new string[] 
            { typeof(ScubaDiver).Name, typeof(FreeDiver).Name };

        private string[] fishTypes = new string[]
            { typeof(DeepSeaFish).Name, typeof(PredatoryFish).Name, typeof(ReefFish).Name };

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!diverTypes.Contains(diverType))
            {
                return String.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.GetModel(diverName) != null)
            {
                return String.Format(OutputMessages.DiverNameDuplication, diverName, typeof(DiverRepository).Name);
            }

            IDiver diver = null;

            if (diverType == "FreeDiver")
            {
                diver = new FreeDiver(diverName);
            }
            else if (diverType == "ScubaDiver")
            {
                diver = new ScubaDiver(diverName);
            }

            divers.AddModel(diver);
            return String.Format(OutputMessages.DiverRegistered, diverName, typeof(DiverRepository).Name);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!fishTypes.Contains(fishType))
            {
                return String.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fish.GetModel(fishName) != null)
            {
                return String.Format(OutputMessages.FishNameDuplication, fishName, typeof(FishRepository).Name);
            }

            IFish newFish = null;
            if (fishType == "DeepSeaFish")
            {
                newFish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == "PredatoryFish")
            {
                newFish = new PredatoryFish(fishName, points);
            }
            else if (fishType == "ReefFish")
            {
                newFish = new ReefFish(fishName, points);
            }
            
            fish.AddModel(newFish);
            return String.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
            {
                return String.Format(OutputMessages.DiverNotFound, typeof(DiverRepository).Name, diverName);
            }

            if (fish.GetModel(fishName) == null)
            {
                return String.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = divers.GetModel(diverName);
            IFish currentFish = fish.GetModel(fishName);

            if (diver.HasHealthIssues == true)
            {
                return String.Format(OutputMessages.DiverHealthCheck, diverName);
            }
           
            if (diver.OxygenLevel < currentFish.TimeToCatch)
            {
                diver.Miss(currentFish.TimeToCatch);
                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }
                return String.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == currentFish.TimeToCatch && !isLucky)
            {
                diver.Miss(currentFish.TimeToCatch);
                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }
                return String.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else
            {
                diver.Hit(currentFish);
                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }
                return String.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
            }
        }

        public string HealthRecovery()
        {
            List<IDiver> diversWithHealthIssues = divers.Models.Where(d => d.HasHealthIssues == true).ToList();

            foreach (var diver in diversWithHealthIssues)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }
            return string.Format(OutputMessages.DiversRecovered, diversWithHealthIssues.Count);
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (var f in diver.Catch)
            {
                IFish currentFish = fish.GetModel(f);
                sb.AppendLine(currentFish.ToString());
            }
            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            List<IDiver> diversReport = divers.Models
                .Where(d => !d.HasHealthIssues)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var d in diversReport)
            {
                sb.AppendLine(d.ToString());
            }

            return sb.ToString().Trim();

        }
    }
}
