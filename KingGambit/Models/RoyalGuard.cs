using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsGambit
{
    public class RoyalGuard : Unit, IKillable, IRactToEvent
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public void ReactToKingBeengAttacked(IAttackable king)
        {
            king.KingIsAttacked += RoyalGuardOnKingIsAttacked;
        }

        private void RoyalGuardOnKingIsAttacked(object sender, EventArgs e)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
