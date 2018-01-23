using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class StatusCommand : Command
    {
        public StatusCommand(string[] args, Engine engine) : base(args, engine)
        {
        }

        public override void Execute()
        {
            IEnumerable<Job> jobs = Engine.JobRepo.Jobs;
            foreach (var job in jobs)
            {
                Console.WriteLine(job);
            }
        }
    }
}
