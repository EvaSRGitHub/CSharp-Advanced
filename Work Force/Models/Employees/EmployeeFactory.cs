using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public class EmployeeFactory
    {
        public IEmployee Create(string[] args)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == args[0]);

            return (IEmployee)Activator.CreateInstance(type, new object[] { args[1] });
        }
    }
}
