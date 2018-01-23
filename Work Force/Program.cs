using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandFactory cmdFactory = new CommandFactory();
            EmployeeFactory emplFactory = new EmployeeFactory();
            JobRepo jobRepo = new JobRepo();

            Engine engine = new Engine(cmdFactory, emplFactory, jobRepo);
            engine.Run();
        }
    }
}
