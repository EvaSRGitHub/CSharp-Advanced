using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsGambit
{
    public interface IAttackable
    {
        event EventHandler KingIsAttacked;
        void RespondToAttack();
    }
}
