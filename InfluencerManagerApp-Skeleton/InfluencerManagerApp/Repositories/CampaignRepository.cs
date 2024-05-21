using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private List<ICampaign> _models;

        public CampaignRepository()
        {
            _models = new List<ICampaign>();
        }

        public IReadOnlyCollection<ICampaign> Models => _models.AsReadOnly();

        public void AddModel(ICampaign model)
        {
            _models.Add(model);
        }

        public bool RemoveModel(ICampaign model)
        {
            if (_models.Remove(model)) return true; return false;
        }

        public ICampaign FindByName(string name)
        {
            return _models.FirstOrDefault(m => m.Brand == name);
        }
    }
}
