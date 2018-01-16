namespace _02.Blobs.Entities
{
    using System;
    using _02.Blobs.Entities.Attacks;
    using _02.Blobs.Entities.Behaviors;
    

    public class Blob:IBlob
    {
        private int health;
        private IAttack attack;
        private IBehavior behavior;
        private int initialHealth;

        public Blob(string name, int health, int damage, IBehavior behavior, IAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.behavior = behavior;
            this.attack = attack;
            this.initialHealth = health;
        }

        public string Name { get; private set; }

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;

                if (this.health < 0)
                {
                    this.health = 0;
                }

                if (this.health <= this.initialHealth / 2 && !this.behavior.IsTriggered)
                {
                    this.TriggerBehavior();
                }
            }
        }

        public int Damage { get; set; }

        public void ProduceAttack(IBlob target)
        {
            this.attack.Execute(this, target);
        }

        public void Respond(int damage)
        {
            this.Health -= damage;
        }

        public void TriggerBehavior()
        {
            this.behavior.Trigger(this);
        }

        public void TryToApplayBehaviorEffect(IBlob blob)
        {
            if (this.behavior.IsTriggered && this.behavior.DelayEffectCounter == 0)
            {
                this.behavior.ApplyEffect(blob);
            }
            else
            {
                this.behavior.ReduceDelayCounter();
            }
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return $"Blob {this.Name} KILLED";
            }

            return $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }

      
    }
}