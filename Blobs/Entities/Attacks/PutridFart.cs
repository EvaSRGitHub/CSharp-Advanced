using System;

namespace _02.Blobs.Entities.Attacks
{
    public class PutridFart : Attack
    {

        public override void Execute(IBlob attacker, IBlob target)
        {
           target.Respond(attacker.Damage);
         //target.Health -= attacker.Damage; 
        }
    }
}