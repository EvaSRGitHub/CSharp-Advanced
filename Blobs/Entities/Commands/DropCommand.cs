using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class DropCommand : Command
    {
        public DropCommand(Engine engine, string[] args) : base(engine, args)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
