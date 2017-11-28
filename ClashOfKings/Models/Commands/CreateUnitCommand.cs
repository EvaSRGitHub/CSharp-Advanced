using System;
using ClashOfKings.Attributes;
using ClashOfKings.Contracts;
using ClashOfKings.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ClashOfKings.Models.Commands
{
    [Command]
    public class CreateUnitCommand : Command
    {
        private const string NonExistentCity = "The city of {0} doesn't exist.";
        private const string HouseCanNotTrainUnits = "House {0} does not have enough funds to train {1} units of {2}";

        public CreateUnitCommand(IGameEngine engine) : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            int numberOfUnits = int.Parse(commandParams[0]);
            string unitType = commandParams[1];
            string cityName = commandParams[2];

            //Author:
            //if (numberOfUnits < 0)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(numberOfUnits), "Number of units should be non-negative");
            //}

            ICollection<IMilitaryUnit> units = this.Engine.UnitFactory.CreateUnits(unitType, numberOfUnits);

            ICity city = this.Engine.Continent.GetCityByName(cityName);
            if (city == null)
            {
                throw new NonExistentCityException(string.Format(NonExistentCity, cityName));
            }

            //Author: check housingAveilability
            if (city.AvailableUnitCapacity(units.First().Type) < units.Sum(u => u.HousingSpacesRequired))
            {
                throw new InsufficientHousingSpacesException(
                    $"City {city.Name} does not have enough housing spaces to accommodate {numberOfUnits} units of {unitType}");
            }

            //try
            //{
            //    city.AddUnits(units);
            //}
            //catch (GameException ex)
            //{
            //    throw new GameException(ex.Message + $" to accommodate {numberOfUnits} units of {unitType}");
            //}

            var controllingHouse = city.ControllingHouse;
            var trainingConst = units.Select(u => u.TrainingCost).First();
            var unitCreateCost = (decimal)(numberOfUnits * trainingConst);

            if (controllingHouse.TreasuryAmount - unitCreateCost < 0)
            {
                throw new InsufficientFundsException(string.Format(HouseCanNotTrainUnits, controllingHouse.Name, numberOfUnits, unitType));
            }

            controllingHouse.TreasuryAmount -= unitCreateCost;

            //Author: lastly add units to city;
            city.AddUnits(units);
            this.Engine.Render($"Successfully added {numberOfUnits} units of {unitType} to city {cityName}");
        }
    }
}
