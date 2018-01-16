using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class BehaviorFactory
    {
        public IBehavior Create(string typeName)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);

            IBehavior behavior = (IBehavior)Activator.CreateInstance(type);

            return behavior;
        }
    }
}
