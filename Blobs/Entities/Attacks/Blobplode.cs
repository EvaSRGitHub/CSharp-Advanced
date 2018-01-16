using _02.Blobs.Entities.Attacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class Blobplode : Attack
    {
        public override void Execute(IBlob attacker, IBlob target)
        {
            attacker.Health -= attacker.Health / 2;
            if(attacker.Health < 1) { attacker.Health = 1; }

            target.Respond(attacker.Damage * 2);
        }
    }
}
