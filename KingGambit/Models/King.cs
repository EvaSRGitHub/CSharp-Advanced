using System;

namespace KingsGambit
{
    public class King : Unit, IAttackable, IRactToEvent
    {
        public event EventHandler KingIsAttacked;

        public King(string name) : base(name)
        {
        }

        public void RespondToAttack()
        {
            this.KingIsAttacked(this, EventArgs.Empty);
        }

        private void KingOnKingIsAttacked(object sender, EventArgs e)
        {
            Console.WriteLine($"King {this.Name} is under attack!");
        }

        public void ReactToKingBeengAttacked(IAttackable king)
        {
            this.KingIsAttacked += KingOnKingIsAttacked;
        }
    }
}
