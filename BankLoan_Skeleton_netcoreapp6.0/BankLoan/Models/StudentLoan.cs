﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int InterestRate = 1;
        private const double Amount = 10000;

        public StudentLoan() : base(InterestRate, Amount)
        {
        }
    }
}
