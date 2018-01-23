using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsGambit
{
    public class UnitFactory
    {
        public IUnit Create(string name, Type type)
        {
            return (IUnit)Activator.CreateInstance(type, new object[]{ name});
        }
    }
}
