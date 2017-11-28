using System;

using ClashOfKings.Models.Armies;
using ClashOfKings.Attributes;

namespace ClashOfKings.Models.ArmyStructures
{
    [ArmyStructure]
    public class DragonLair : ArmyStructure
    {
        private const decimal DragonLairBuildCost = 200000;
        private const int DragonLairCapacity = 3;
        private const CityType DragonLairMinCityType = CityType.Capital;
        private const UnitType DragonLairUnitType = UnitType.AirForce;

        public DragonLair() : base(DragonLairBuildCost, DragonLairCapacity, DragonLairMinCityType, DragonLairUnitType)
        {
        }
    }
}
