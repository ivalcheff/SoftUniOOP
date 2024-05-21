using System;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models
{
    public abstract class Client : IClient
    {
        private string _name;
        private string _id;
        private int _interest;
        private double _income;

        public Client(string name, string id, int interest, double income)
        {
            Name = name;
            Id = id;
            _interest = interest;
            Income = income;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClientNameNullOrWhitespace);
                }
                this._name = value;
            }
        }

        public string Id
        {
            get => _id;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClientIdNullOrWhitespace);
                }
                this._id = value;
            }
        }

        public int interest
        {
            get => _interest;
            protected set => _interest = value ;
        }

        public double Income
        {
            get => _income;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.ClientIncomeBelowZero);
                }
                this._income = value;
            }
        }

        public abstract void IncreaseInterest();

    }
}
