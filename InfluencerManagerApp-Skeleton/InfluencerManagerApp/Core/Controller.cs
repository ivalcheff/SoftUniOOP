using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }
        public string RegisterInfluencer(string typeName, string username, int followers)
        {

            if (influencers.FindByName(username) != null)
            {
                return String.Format(OutputMessages.UsernameIsRegistered, username, typeof(InfluencerRepository).Name);
            }

            IInfluencer influencer = null;
            if (typeName == "BloggerInfluencer")
            {
                influencer = new BloggerInfluencer(username, followers);
            }
            else if (typeName == "BusinessInfluencer")
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == "FashionInfluencer")
            {
                influencer = new FashionInfluencer(username, followers);
            }
            else
            {
                return String.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            influencers.AddModel(influencer);
            return String.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            ICampaign campaign = null;

            if (campaigns.FindByName(brand) != null)
            {
                return String.Format(OutputMessages.CampaignDuplicated, brand);
            }

            if (typeName == "ProductCampaign")
            {
                campaign = new ProductCampaign(brand);
            }
            else if (typeName == "ServiceCampaign")
            {
                campaign = new ServiceCampaign(brand);
            }
            else
            {
                return String.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            campaigns.AddModel(campaign);
            return String.Format(OutputMessages.CampaignStartedSuccessfully, brand, campaign.GetType().Name);
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = influencers.FindByName(username);
            ICampaign campaign = campaigns.FindByName(brand);
            if (influencer == null)
            {
                return String.Format(OutputMessages.InfluencerNotFound, influencers.GetType().Name, username);
            }

            if (campaign == null)
            {
                return String.Format(OutputMessages.CampaignNotFound, brand);
            }

            if (campaign.Contributors.Contains(username))
            {
                return String.Format(OutputMessages.InfluencerAlreadyEngaged,username, brand);
            }

            if (campaign.GetType() == typeof(ProductCampaign) && influencer.GetType() == typeof(BloggerInfluencer))
            {
                return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaign.GetType() == typeof(ServiceCampaign) && influencer.GetType() == typeof(FashionInfluencer))
            {
                return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaign.Budget < influencer.CalculateCampaignPrice())
            {
                return String.Format(OutputMessages.UnsufficientBudget,brand, username );
            }

            influencer.EarnFee(influencer.CalculateCampaignPrice());
            influencer.EnrollCampaign(brand);
            campaign.Engage(influencer);

            return String.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount < 0)
            {
                return String.Format(OutputMessages.NotPositiveFundingAmount);
            }

            campaign.Gain(amount);

            return String.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount );
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToClose);
            }

            
            if (campaign.Budget > 10000)
            {
                foreach (var contributor in campaign.Contributors)
                {
                    influencers.FindByName(contributor).EarnFee(2000);
                    influencers.FindByName(contributor).EndParticipation(brand);
                }

                campaigns.RemoveModel(campaign);
                return String.Format(OutputMessages.CampaignClosedSuccessfully, brand);
            }
            else
            {
                return String.Format(OutputMessages.CampaignCannotBeClosed, campaign.Brand);
            }
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);
            if (influencer == null)
            {
                return String.Format(OutputMessages.InfluencerNotSigned, username);
            }

            if (influencer.Participations.Count != 0)
            {
                return String.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            influencers.RemoveModel(influencer);
            return String.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            List<IInfluencer> influencerReport = influencers.Models
                .OrderByDescending(i => i.Income)
                .ThenByDescending(i => i.Followers)
                .ToList();

            foreach (var influencer in influencerReport)
            {
                sb.AppendLine(influencer.ToString());
                sb.AppendLine("Active Campaigns:");

                if (influencer.Participations != null)
                {
                    List<ICampaign> activeCampaigns = new List<ICampaign>();

                    foreach (var brand in influencer.Participations)
                    {
                        activeCampaigns.Add(campaigns.FindByName(brand));
                    }

                    List<ICampaign> orededCampaigns = activeCampaigns.OrderBy(c => c.Brand).ToList();


                    foreach (ICampaign campaign in orededCampaigns)
                    {
                        sb.AppendLine("--" + campaign.ToString());
                    }

                }
            }
            return sb.ToString().Trim();
        }
    }
}
