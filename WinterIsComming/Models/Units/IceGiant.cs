using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class IceGiant : Unit
    {
        private const int IceGiantAttackPoints = 150;
        private const int IceGiantHealthPoints = 300;
        private const int IceGiantDefensePoints = 60;
        private const int IceGiantEnergyPoints = 50;
        private const int IceGiantRange = 1;

        public IceGiant(string name, int x, int y) : base(name, x, y)
        {
            this.AttackPoints = IceGiantAttackPoints;
            this.HealthPoints = IceGiantHealthPoints;
            this.DefensePoints = IceGiantDefensePoints;
            this.EnergyPoints = IceGiantEnergyPoints;
            this.Range = IceGiantRange;
            this.CombatHandler = new CombatHandler(this);
        }


      

    }
}
