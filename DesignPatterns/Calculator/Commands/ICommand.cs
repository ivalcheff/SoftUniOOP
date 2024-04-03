using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public interface ICommand
    {
        public char Operator { get; set; }
        public decimal Value { get; set; }  


        public decimal Execute(decimal current);

        public decimal UnExecute(decimal current);

    }
}
