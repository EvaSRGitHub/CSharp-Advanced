using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public interface IBehavior
    {
       int DelayEffectCounter { get; }

        bool IsTriggered { get; }

        void ReduceDelayCounter();

        void Trigger(IBlob source);

        void ApplyEffect(IBlob source);
    }
}
