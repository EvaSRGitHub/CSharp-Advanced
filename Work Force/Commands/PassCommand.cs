using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class PassCommand : Command
    {
        public PassCommand(string[] args, Engine engine) : base(args, engine)
        {
        }

        public override void Execute()
        {
            IEnumerable<Job> jobs = Engine.JobRepo.Jobs;
            
            IList<Job> finishedJobs = new List<Job>();
            foreach (var job in jobs)
            {
                job.Update();
                if (job.IsJobFinished)
                {
                    finishedJobs.Add((job));
                }
            }

            Engine.JobRepo.RemoveJob(finishedJobs);
        }
    }
}
