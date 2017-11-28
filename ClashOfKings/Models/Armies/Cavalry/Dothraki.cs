using System;
using ClashOfKings.Attributes;

namespace ClashOfKings.Models.Armies.Cavalry
{
    [MilitaryUnit]
    class Dothraki : MilitaryUnit
    {
        private const int DothrakiArmor = 5;
        private const int DothrakiDamage = 25;
        private const decimal DothrakiTrainingCost = 25;
        private const double DothrakiUpkeepCost = 1.8;
        private const int DothrakiHouseingSpaceRequired = 2;
        private const UnitType DothrakiType = UnitType.Cavalry;

        public Dothraki() : base(DothrakiArmor, DothrakiDamage, DothrakiTrainingCost, DothrakiUpkeepCost, DothrakiHouseingSpaceRequired, DothrakiType)
        {
        }
    }
}
