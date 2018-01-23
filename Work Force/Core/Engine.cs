using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class Engine
    {
        private CommandFactory cmdFactory;
        private EmployeeFactory emplFactory;
        private JobRepo jobRepo;
        private List<IEmployee> employees;

        public Engine(CommandFactory cmdFactory, EmployeeFactory emplFactory, JobRepo jobRepo)
        {
            this.cmdFactory = cmdFactory;
            this.emplFactory = emplFactory;
            this.jobRepo = jobRepo;
            this.employees = new List<IEmployee>();
        }

        public CommandFactory CmdFactory { get { return this.cmdFactory; } }

        public EmployeeFactory EmplFactory { get { return this.emplFactory; } }

        public JobRepo JobRepo { get { return this.jobRepo; } }

        public IEnumerable<IEmployee> Employees { get { return this.employees; } }

        public void AddEmployee(IEmployee employee)
        {
            this.employees.Add(employee);
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine())!= "End")
            {
                string[] args = input.Split();
                CommandInterpreter(args, this);
            }
        }

        private void CommandInterpreter(string[] args, Engine engine)
        {
            Command command = this.CmdFactory.Create(args, engine);
            command.Execute();
        }
    }
}