using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public class FireBreath : Spell
    {
        public FireBreath(IUnit unit) : base(unit)
        {
            this.Damage = GetDamage(unit);
            this.EnergyCost = 30;
        }

        private int GetDamage(IUnit unit)
        {
            return unit.AttackPoints;
        }
    }
}
