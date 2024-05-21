using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private List<IInfluencer> _models;

        public InfluencerRepository() 
        { 
            _models = new List<IInfluencer>();
        }

        public IReadOnlyCollection<IInfluencer> Models => _models.AsReadOnly();

        public void AddModel(IInfluencer model)
        {
            _models.Add(model);
        }

        public bool RemoveModel(IInfluencer model)
        {
            if (_models.Remove(model)) return true; return false;
        }

        public IInfluencer FindByName(string name)
        {
            return _models.FirstOrDefault(m => m.Username == name);
        }
    }
}
