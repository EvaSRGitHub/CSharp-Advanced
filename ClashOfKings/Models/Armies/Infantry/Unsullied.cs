using System;
using ClashOfKings.Attributes;

namespace ClashOfKings.Models.Armies.Infantry
{
    [MilitaryUnit]
    class Unsullied : MilitaryUnit
    {
        private const int UnsulliedArmor = 5;
        private const int UnsulliedDamage = 25;
        private const decimal UnsulliedTrainingCost = 42.5m;
        private const double UnsulliedUpkeepCost = 0.75;
        private const int UnsulliedHousingSpaceRequired = 1;
        private const UnitType UnsulliedType = UnitType.Infantry; 

        public Unsullied() 
            : base(UnsulliedArmor, UnsulliedDamage, UnsulliedTrainingCost, UnsulliedUpkeepCost, UnsulliedHousingSpaceRequired, UnsulliedType)
        {
        }
    }
}
