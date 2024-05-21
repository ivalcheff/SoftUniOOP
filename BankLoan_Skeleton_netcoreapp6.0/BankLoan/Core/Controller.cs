using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Core.Contracts;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        public string AddBank(string bankTypeName, string name)
        {
            throw new NotImplementedException();
        }

        public string AddLoan(string loanTypeName)
        {
            throw new NotImplementedException();
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            throw new NotImplementedException();
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            throw new NotImplementedException();
        }

        public string FinalCalculation(string bankName)
        {
            throw new NotImplementedException();
        }

        public string Statistics()
        {
            throw new NotImplementedException();
        }
    }
}
