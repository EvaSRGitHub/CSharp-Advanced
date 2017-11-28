using System;
using ClashOfKings.Contracts;
using ClashOfKings.Models.Armies;

namespace ClashOfKings.Models.ArmyStructures
{
    public abstract class ArmyStructure : IArmyStructure
    {
        private decimal buildCost;
        private int capacity;
        private CityType cityType;
        private UnitType unitType;

        protected ArmyStructure(decimal buildCost, int capacity, CityType cityType, UnitType unitType)
        {
            this.BuildCost = buildCost;
            this.Capacity = capacity;
            this.RequiredCityType = cityType;
            this.UnitType = unitType;
        }

        public decimal BuildCost
        {
            get
            {
                return this.buildCost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                         nameof(buildCost),
                          "An army structure building cost cannot be negative");
                }
                this.buildCost = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if(value < 0) { throw new ArgumentOutOfRangeException(nameof(capacity), "An army structure capacity can't be negative"); }
                this.capacity = value;
            }
        }

        public CityType RequiredCityType { get; private set; }

        public UnitType UnitType {get; private set;}
    }
}
