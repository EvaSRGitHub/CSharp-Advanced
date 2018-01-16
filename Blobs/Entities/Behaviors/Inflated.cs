using _02.Blobs.Entities.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class Inflated : Behavior
    {
        private const int InflatedHealthMultiplier = 50;
        private const int InflatedHealthDecrementer = 10;


        public override void ApplyEffect(IBlob source)
        {
            source.Health -= InflatedHealthDecrementer;
        }

        public override void Trigger(IBlob source)
        {
            this.IsTriggered = true;
            this.DelayEffectCounter++;
            source.Health += InflatedHealthMultiplier;

        }
    }
}
