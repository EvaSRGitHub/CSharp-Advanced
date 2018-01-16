using System;

namespace _02.Blobs.Entities.Behaviors
{
    public class Aggressive : Behavior
    {
        private static int AggressiveDamageMultiplier = 2;
        private static int AggressiveDamageDecrementer = 5;
        private int sourceInitialDamage;

        public override void Trigger(IBlob source)
        {
            this.sourceInitialDamage = source.Damage;
            source.Damage *= AggressiveDamageMultiplier;
            this.IsTriggered = true;
            this.DelayEffectCounter++;
        }

        public override void ApplyEffect(IBlob source)
        {
            if (source.Damage - AggressiveDamageDecrementer >= this.sourceInitialDamage)
            { source.Damage -= AggressiveDamageDecrementer; }
            else { source.Damage = this.sourceInitialDamage; }
        }
    }
}