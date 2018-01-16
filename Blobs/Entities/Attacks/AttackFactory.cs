using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class AttackFactory
    {
        public IAttack Create(string typeName)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);

            IAttack attack = (IAttack)Activator.CreateInstance(type);

            return attack;
        }
    }
}
