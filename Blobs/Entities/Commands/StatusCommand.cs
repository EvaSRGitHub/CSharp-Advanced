using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class StatusCommand : Command
    {
        public StatusCommand(Engine engine, string[] args) : base(engine, args)
        {
        }

        public override void Execute()
        {
            foreach (var blob in base.Engine.Blobs)
            {
                base.Engine.Console.LineWriter(blob.ToString());
            }
        }
    }
}
