using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class JobRepo
    {
        private List<Job> jobs;

        public JobRepo()
        {
            this.jobs = new List<Job>();
        }

        public IEnumerable<Job> Jobs
        {
            get { return this.jobs; }
        }

        public void AddJob(Job job)
        {
            this.jobs.Add(job);

            job.JobFinished += OnJobFinised;
        }

        public void RemoveJob(IList<Job> jobsToRemove)
        {
            for (int i = 0; i < jobsToRemove.Count; i++)
            {
                this.jobs.Remove(jobsToRemove[i]);
            }
        }
        private void OnJobFinised(object sender, EventArgs e)
        {
            Console.WriteLine($"Job {((Job)sender).Name} done!");

            ((Job)sender).JobFinished -= OnJobFinised;

           /// this.jobs.Remove(((Job)sender));
        }
    }
}
