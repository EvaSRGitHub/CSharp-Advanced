
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public interface IBlob
    {
        string Name { get; }

        int Health { get; set; }

        int Damage { get; set; }

        void ProduceAttack(IBlob target);

        void Respond(int damage);

        void TriggerBehavior();

        void TryToApplayBehaviorEffect(IBlob blob);
    }
}
