using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class Mage : Unit
    {
        private const int MageAttackPoints = 80;
        private const int MageHealthPoints = 80;
        private const int MageDefensePoints = 40;
        private const int MageEnergyPoints = 120;
        private const int MageRange = 2;

        public Mage(string name, int x, int y) : base(name, x, y)
        {
            this.AttackPoints = MageAttackPoints;
            this.HealthPoints = MageHealthPoints;
            this.DefensePoints = MageDefensePoints;
            this.EnergyPoints = MageEnergyPoints;
            this.Range = MageRange;
            this.CombatHandler = new CombatHandler(this);
        }

        public bool IsLastSpellSuccessfull { get; set; }

        public string LastSpell { get; set; }


    }
}
