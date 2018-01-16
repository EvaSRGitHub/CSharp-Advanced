using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class PassCommand : Command
    {
        public PassCommand(Engine engine, string[] args) : base(engine, args)
        {
        }

        public override void Execute()
        {
            //i am fucked here!
        }
    }
}
