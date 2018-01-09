using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public class Cleave : Spell
    {
        public Cleave(IUnit unit) : base(unit)
        {
            this.Damage = GetDamage(unit);
            this.EnergyCost = 15;
          
        }

        private int GetDamage(IUnit unit)
        {

            if (unit.HealthPoints <= 80)
            {
              return unit.AttackPoints + unit.HealthPoints * 2;
            }
            return unit.AttackPoints; 
        }

        


    }
}
