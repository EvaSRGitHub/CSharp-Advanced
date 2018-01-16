using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class CommandFactory
    {
        public ICommand Create(Engine engine, string[] args)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            string commandName = ti.ToTitleCase(args[0]);

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

            ICommand command = (ICommand)Activator.CreateInstance(type, engine, args);

            return command;
        }
    }
}
