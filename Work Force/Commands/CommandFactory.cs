using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class CommandFactory
    {
        public Command Create(string[] args, Engine engine)
        {
           if(args[0] == "StandartEmployee" || args[0] == "PartTimeEmployee")
            {
                return new CreateEmployeeCommand(args, engine);
                
            }

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == args[0]+"Command");

            return (Command)Activator.CreateInstance(type, new object[] { args, engine });


        }
    }
}
