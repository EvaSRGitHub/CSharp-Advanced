using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Models.Spells;
using WinterIsComing.Models.Units;
using WinterIsComing.Core.Exceptions;
using WinterIsComing.Core;

namespace WinterIsComing.Models.CombatHandlers
{
    public class CombatHandler : ICombatHandler
    {
        public CombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; set; }

        public ISpell GenerateAttack()
        {
            ISpell spell;
            string type = this.Unit.GetType().Name;
            switch (type)
            {
                case "IceGiant":
                    spell = new Stomp(this.Unit);
                    VerifyEnergy(spell);
                    this.Unit.AttackPoints += 5;
                    this.Unit.EnergyPoints -= spell.EnergyCost;
                    return spell;

                case "Warrior":
                    spell = new Cleave(this.Unit);
                    VerifyEnergy(spell);
                    if (this.Unit.HealthPoints > 50)
                    {
                        this.Unit.EnergyPoints -= spell.EnergyCost;
                    }
                    return spell;

                case "Mage":
                    var mage = this.Unit as Mage;
                    if (mage.LastSpell == "FireBreath")
                    {
                        spell = new Blizzard(this.Unit);
                    }
                    else
                    {
                        spell = new FireBreath(this.Unit);
                    }
                    VerifyEnergy(spell);
                    this.Unit.EnergyPoints -= spell.EnergyCost;
                    mage.IsLastSpellSuccessfull = true;
                    mage.LastSpell = spell.GetType().Name;
                    return spell;

                default:
                    throw new ArgumentException("Unit type.");
            }
        }

        private void VerifyEnergy(ISpell spell)
        {
            if (this.Unit.EnergyPoints - spell.EnergyCost < 0)
            {
                throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, Unit.Name, spell.GetType().Name));
            }
        }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            string type = this.Unit.GetType().Name;
            switch (type)
            {
                case "Mage":
                    return candidateTargets.OrderByDescending(u => u.HealthPoints).ThenBy(u => u.Name).Take(3).ToList();

                case "Warrior":
                    return candidateTargets.OrderBy(u => u.HealthPoints).ThenBy(u => u.Name).Take(1);

                case "IceGiant":
                    if(this.Unit.HealthPoints <= 150)
                    {
                        return candidateTargets.Take(1);
                    }
                    return candidateTargets;
                default:
                    return null;
            }

        }
    }
}
