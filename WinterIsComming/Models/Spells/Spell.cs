using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public abstract class Spell : ISpell
    {
        private int damage;
        private int energyCost;
        private IUnit unit;

        protected Spell(IUnit unit)
        {
            this.unit = unit;
        }

        public int Damage { get; protected set; }

        public int EnergyCost { get; protected set; }
    }
}
