using System;
using ClashOfKings.Attributes;
using ClashOfKings.Models.Armies;

namespace ClashOfKings.Models.ArmyStructures
{
    [ArmyStructure]
    public class Stable:ArmyStructure
    {
        private const decimal StableBuildCost = 75000;
        private const int StableCapacity = 2500;
        private const CityType StableMinCityType = CityType.FortifiedCity;
        private const UnitType StableUnitType = UnitType.Cavalry;

        public Stable() : base(StableBuildCost, StableCapacity, StableMinCityType, StableUnitType)
        {
        }
    }
}
