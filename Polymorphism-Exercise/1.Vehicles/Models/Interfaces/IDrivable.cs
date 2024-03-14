using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models.Interfaces
{
    public interface IDrivable
    {
        public void Drive(double distance);


        void Refuel(double fuel);
     

    }
}
