using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    internal class ClimberRepository : IRepository<IClimber>
    {
        private List<IClimber> _all;

        public ClimberRepository()
        {
            _all = new List<IClimber>();
        }
        public IReadOnlyCollection<IClimber> All { get => _all.AsReadOnly(); }
        public void Add(IClimber model)
        {
            _all.Add(model);
        }

        public IClimber Get(string name)
        {
            return _all.FirstOrDefault(m => m.Name == name);
        }
    }
}
