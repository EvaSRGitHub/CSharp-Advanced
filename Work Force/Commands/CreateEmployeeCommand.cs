using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class CreateEmployeeCommand : Command
    {
        public CreateEmployeeCommand(string[] args, Engine engine) : base(args, engine) { }

        public override void Execute()
        {
            IEmployee employee = Engine.EmplFactory.Create(Args);
            Engine.AddEmployee(employee);
        }
    }
}
