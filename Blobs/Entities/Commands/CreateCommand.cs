using _02.Blobs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class CreateCommand : Command
    {
        public CreateCommand(Engine engine, string[] args) : base(engine, args)
        {
        }

        public override void Execute()
        {
            string blobName = base.Args[1];
            int health = int.Parse(base.Args[2]);
            int damage = int.Parse(base.Args[3]);
            IBehavior behavior = base.Engine.CreateBehavior.Create(base.Args[4]);
            IAttack attack = base.Engine.CreateAttack.Create(base.Args[5]);

            IBlob blob = new Blob(blobName, health, damage, behavior, attack);

            Engine.AddBlob(blob);
        }
    }
}
