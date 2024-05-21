using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> _models;

        public BankRepository()
        {
            _models = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models => _models.AsReadOnly();

        public void AddModel(IBank model)
        {
            _models.Add(model);
        }

        public bool RemoveModel(IBank model)
        {
            if (_models.Remove(model)) return true;
            return false;
        }

        public IBank FirstModel(string name)
        {
            _models.FirstOrDefault(m => m.GetType().Name == name);
        }
    }
}
