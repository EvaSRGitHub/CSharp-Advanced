using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsGambit
{
    public class Footman : Unit, IKillable, IRactToEvent
    {
        public Footman(string name) : base(name)
        {
        }

        public void ReactToKingBeengAttacked(IAttackable king)
        {
            king.KingIsAttacked += FootmanOnKingIsAttacked;
        }

        private void FootmanOnKingIsAttacked(object sender, EventArgs e)
        {
           Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
