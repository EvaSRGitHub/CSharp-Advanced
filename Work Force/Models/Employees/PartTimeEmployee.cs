using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class PartTimeEmployee : Employee
    {
        private const int PartTimeEmployeeDefaultHours = 20;

        public PartTimeEmployee(string name) : base(name, PartTimeEmployeeDefaultHours)
        {
        }
    }
}
