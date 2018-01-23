using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class Job
    {
        public event EventHandler JobFinished;
        private string name;
        private int hoursRequired;
        private bool isJobFinished;
        private IEmployee employee;

        public Job(string name, int hoursRequired, IEmployee employee)
        {
            this.name = name;
            this.hoursRequired = hoursRequired;
            this.isJobFinished = false;
            this.employee = employee;
        }

        public string Name { get { return this.name; } }

        public bool IsJobFinished { get { return this.isJobFinished; } private set { this.isJobFinished = value; } }

        public int HoursRequired
        {
            get { return this.hoursRequired; }
            private set { this.hoursRequired = value; }
        }

        public void Update()
        {
            this.HoursRequired -= this.employee.Hours;

            if(this.HoursRequired <= 0)
            {
                this.IsJobFinished = true;
                this.JobFinished(this, EventArgs.Empty);
            }
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursRequired}";
        }
    }
}
