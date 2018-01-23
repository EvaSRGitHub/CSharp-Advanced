using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class JobCommand : Command
    {
        public JobCommand(string[] args, Engine engine) : base(args, engine)
        {
        }

        public override void Execute()
        {
            IEmployee employeeToDoTheJob = Engine.Employees.FirstOrDefault(en => en.Name == Args[3]);

            Job job = new Job(Args[1], int.Parse(Args[2]), employeeToDoTheJob);

            Engine.JobRepo.AddJob(job);
        }

    }
}
