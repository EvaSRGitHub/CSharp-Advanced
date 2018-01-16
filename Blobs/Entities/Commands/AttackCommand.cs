using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class AttackCommand : Command
    {
        public AttackCommand(Engine engine, string[] args) : base(engine, args)
        {
        }

        public override void Execute()
        {
            IBlob attacker = base.Engine.Blobs.FirstOrDefault(b => b.Name == base.Args[1]);

            IBlob target = base.Engine.Blobs.FirstOrDefault(b => b.Name == base.Args[2]);

            attacker.ProduceAttack(target);
        }
    }
}
