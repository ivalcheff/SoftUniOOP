using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private PeakRepository peaks;
        private ClimberRepository climbers;
        private BaseCamp baseCamp;

        public Controller()
        {
            peaks = new PeakRepository();
            climbers = new ClimberRepository();
            baseCamp = new BaseCamp();
        }
        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.Get(name) != null)
            {
                return String.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return String.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }
           
            IPeak peak = new Peak(name, elevation, difficultyLevel);
            peaks.Add(peak);
            return String.Format(OutputMessages.PeakIsAllowed, name, typeof(PeakRepository).Name);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.Get(name) != null)
            {
                return String.Format(OutputMessages.ClimberCannotBeDuplicated, name, typeof(ClimberRepository).Name);
            }

            IClimber climber;

            if (isOxygenUsed)
            {
                climber = new OxygenClimber(name);
            }
            else
            {
                climber = new NaturalClimber(name);
            }

            climbers.Add(climber);
            baseCamp.ArriveAtCamp(name);

            return String.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string AttackPeak(string climberName, string peakName)
        {

            IClimber climber = climbers.Get(climberName);
            IPeak peak = peaks.Get(peakName);

            if (climber == null)
            {
                return String.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if (peak == null)
            {
                return String.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!baseCamp.Residents.Contains(climberName))
            {
                return String.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            if (peak.DifficultyLevel == "Extreme" &&
                climber.GetType() == typeof(NaturalClimber))
            {
                return String.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);
            if (climber.Stamina == 0)
            {
                return String.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }
            
            baseCamp.ArriveAtCamp(climberName);
            return String.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!baseCamp.Residents.Contains(climberName))
            {
                return String.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climber = climbers.Get(climberName);

            if (climber.Stamina == 10)
            {
                return String.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }

            if (climber.Stamina < 10)
            {
                climber.Rest(daysToRecover);
                return String.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
            }
            return null;
        }

        public string BaseCampReport()
        {
            if (baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }

            List<IClimber> climbersInBaseCamp = new List<IClimber>();
            IClimber climber;

            foreach (var name in baseCamp.Residents)
            {
                climber = climbers.Get(name);
                climbersInBaseCamp.Add(climber);
            }

            List<IClimber> ordedredClimbers = climbersInBaseCamp.OrderBy(c => c.Name).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("BaseCamp residents:");

            foreach (var c in ordedredClimbers)
            {
                sb.AppendLine($"Name: {c.Name}, Stamina: {c.Stamina}, Count of Conquered Peaks: {c.ConqueredPeaks.Count}");
            }
            return sb.ToString().Trim();
        }

        public string OverallStatistics()
        {
            List<IClimber> climbersList = climbers.All
                .OrderByDescending(c => c.ConqueredPeaks.Count)
                .ThenBy(c => c.Name)
                .ToList();


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");

            foreach (var climber in climbersList)
            {
                sb.AppendLine(climber.ToString());

                IPeak currentPeak;
                List < IPeak> peakList = new List<IPeak>();
                foreach (var name in climber.ConqueredPeaks)
                {
                    currentPeak = peaks.Get(name);
                    peakList.Add(currentPeak);
                }

                List<IPeak> orderedPeakList = peakList
                    .OrderByDescending(p => p.Elevation)
                    .ToList();

                foreach (var peak in orderedPeakList)
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
