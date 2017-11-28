using System;
using ClashOfKings.Attributes;

namespace ClashOfKings.Models.Armies.AirForce
{
    [MilitaryUnit]
    class Dragon : MilitaryUnit
    {
        private const int DragonArmor = 700;
        private const int DragonDamage = 1200;
        private const decimal DragonTrainingCost = 1500;
        private const double DragonUpkeepCost = 100;
        private const int DragonHousingSpaceRequired = 1;
        private const UnitType DragonType = UnitType.AirForce;

        public Dragon() : base(DragonArmor, DragonDamage, DragonTrainingCost, DragonUpkeepCost, DragonHousingSpaceRequired, DragonType)
        {
        }
    }
}
