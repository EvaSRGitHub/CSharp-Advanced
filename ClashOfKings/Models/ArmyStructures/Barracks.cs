using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClashOfKings.Models.Armies;
using ClashOfKings.Attributes;

namespace ClashOfKings.Models.ArmyStructures
{
    [ArmyStructure]
    public class Barracks : ArmyStructure
    {
        private const decimal BarracksBuildCost = 15000;
        private const int BarracksCapacity = 5000;
        private const CityType BarracksMinCityType = CityType.Keep;
        private const UnitType BarracksUnitType = UnitType.Infantry;

        public Barracks() : base(BarracksBuildCost, BarracksCapacity, BarracksMinCityType, BarracksUnitType)
        {
        }
    }
}
