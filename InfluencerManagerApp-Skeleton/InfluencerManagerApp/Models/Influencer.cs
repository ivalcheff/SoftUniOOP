using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private const int InitialIncome = 0;
        private string _username;
        private int _followers;
        private double _income;
        private List<string> _participations;

        public Influencer(string username, int followers, double engagementRate)
        {
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            _participations = new List<string>();
        }

        public string Username
        {
            get => _username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }
                this._username = value;
            }
        }

        public int Followers
        {
            get => this._followers;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }
                this._followers = value;
            }
        }

        public double EngagementRate { get; set; }

        public double Income
        {
            get => _income;
            set
            {
                _income = InitialIncome;
            }
        }

        public IReadOnlyCollection<string> Participations
        {
            get => _participations;
        }


        public void EarnFee(double amount)
        {
            this._income += amount;
        }

        public void EnrollCampaign(string brand)
        {
            _participations.Add(brand);
        }

        public void EndParticipation(string brand)
        {
            _participations.Remove(brand);
        }

        public abstract int CalculateCampaignPrice();
       

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
