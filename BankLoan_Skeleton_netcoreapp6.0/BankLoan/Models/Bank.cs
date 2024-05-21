using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string _name;
        private int _capacity;
        private List<ILoan> _loans;
        private List<IClient> _clients;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _clients = new List<IClient>();
            _loans = new List<ILoan>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                this._name = value;
            }
        }

        public int Capacity
        {
            get => _capacity;
            set => _capacity = value;
        }

        public IReadOnlyCollection<ILoan> Loans => _loans;

        public IReadOnlyCollection<IClient> Clients => _clients;

        public double SumRates()
        {
            double sumRates = 0;

            foreach (var loan in _loans)
            {
                sumRates += loan.InterestRate;
            }
            return sumRates;
        }

        public void AddClient(IClient Client)
        {
            if (this.Capacity <= this._clients.Count)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
            _clients.Add(Client);
        }

        public void RemoveClient(IClient Client)
        {
            _clients.Remove(Client);
        }

        public void AddLoan(ILoan loan)
        {
            _loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");

            if (this._clients.Count == 0)
            {
                sb.AppendLine("Clients: none");
            }
            else
            {
                sb.Append("Clients: ");
                foreach (var client in _clients)
                {
                    sb.Append($"{client.Name}, ");
                }
            }

            sb.AppendLine($"Loans: {_loans.Count}, Sum of Rates: {this.SumRates()}");

            return sb.ToString().Trim();
        }
    }
}
