using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public abstract class Employee : IEmployee
    {

        protected Employee(string name, int hours)
        {
            this.Name = name;
            this.Hours = hours;
        }

        public int Hours {get;}

        public string Name {get;}
    }
}
