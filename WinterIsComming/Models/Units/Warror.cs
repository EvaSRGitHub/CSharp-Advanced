using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class Warrior: Unit
    {
        private const int WarriorAttackPoints = 120;
        private const int WarriorHealthPoints = 180;
        private const int WarriorDefensePoints = 70;
        private const int WarriorEnergyPoints = 60;
        private const int WarriorRange = 1;

        public Warrior(string name, int x, int y) : base(name, x, y)
        {
            this.AttackPoints = WarriorAttackPoints;
            this.HealthPoints = WarriorHealthPoints;
            this.DefensePoints= WarriorDefensePoints;
            this.EnergyPoints = WarriorEnergyPoints;
            this.Range = WarriorRange;
            this.CombatHandler = new CombatHandler(this);
        }

        
    }
}
