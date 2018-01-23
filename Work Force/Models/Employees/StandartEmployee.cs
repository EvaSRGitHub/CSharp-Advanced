using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class StandartEmployee : Employee
    {
        private const int StandardEmployeeDefaultHours = 40;

        public StandartEmployee(string name) : base(name, StandardEmployeeDefaultHours)
        {
        }
    }
}
