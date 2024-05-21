using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> _models;

        public LoanRepository()
        {
            _models = new List<ILoan>();
        }
        public IReadOnlyCollection<ILoan> Models => _models.AsReadOnly();

        public void AddModel(ILoan model)
        {
            _models.Add(model);
        }

        public bool RemoveModel(ILoan model)
        {
            if (_models.Remove(model)) return true; return false;
        }

        public ILoan FirstModel(string name)
        {
           return _models.FirstOrDefault(m => m.GetType().Name == name);
        }
    }
}
