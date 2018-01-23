using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsGambit
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleReaderAndWriter console = new ConsoleReaderAndWriter();
            UnitFactory unitFactory = new UnitFactory();

            Engine engine = new Engine(console, unitFactory);
            engine.Run();
        }
    }
}
