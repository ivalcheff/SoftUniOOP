using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using System.Reflection;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        
        private List<IPeak> _all;

        public PeakRepository()
        {
            _all = new List<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All { get => _all.AsReadOnly(); }
        public void Add(IPeak model)
        {
            _all.Add(model);
        }

        public IPeak Get(string name)
        {
            return _all.FirstOrDefault(m => m.Name == name);
        }
    }
}
