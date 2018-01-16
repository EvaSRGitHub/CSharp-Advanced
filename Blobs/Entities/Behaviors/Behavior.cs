using System;

namespace _02.Blobs.Entities.Behaviors
{
    public abstract class Behavior: IBehavior
    {
        

        public Behavior()
        {
            this.IsTriggered = false;
            this.DelayEffectCounter = 0;
        }

        public  int DelayEffectCounter { get; protected set; }

        public bool IsTriggered { get; protected set; }

        public abstract void Trigger(IBlob source);

        public abstract void ApplyEffect(IBlob source);

        public void ReduceDelayCounter()
        {
            this.DelayEffectCounter = 0;
        }
    }
}