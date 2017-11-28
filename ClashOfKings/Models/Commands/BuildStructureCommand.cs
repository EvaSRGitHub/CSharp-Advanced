using System;
using ClashOfKings.Attributes;
using ClashOfKings.Contracts;
using ClashOfKings.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ClashOfKings.Models.Commands
{
    [Command]
    public class BuildStructureCommand : Command
    {
        private const string NonExistentCity = "The city of {0} doesn't exist.";
        private const string HouseCanNotBuildStructure = "House {0} doesn't have sufficient funds to build {1}";
        private const string InsufficientCitySizeErrorMessage =
           "Structure requires a more advanced city";

        public BuildStructureCommand(IGameEngine engine) : base(engine) { }

        public override void Execute(params string[] commandParams)
        {
            string structureName = commandParams[0];
            string cityName = commandParams[1];

            ICity city = this.Engine.Continent.GetCityByName(cityName);
            if(city == null)
            {
                throw new NonExistentCityException(string.Format(NonExistentCity, nameof(cityName)));
            }
            //Ne triabla li parvo da proveria usloviata i posle da sazdavam structure?
            var structure = this.Engine.ArmyStructureFactory.CreateStructure(structureName);

            if(city.CityType < structure.RequiredCityType)
            {
                throw new InsufficientCitySizeException(string.Format(InsufficientCitySizeErrorMessage, cityName, structureName));
            }

            var controllingHouse = city.ControllingHouse;
            var structureCost = structure.BuildCost;
            if(controllingHouse.TreasuryAmount - structureCost < 0)
            {
                throw new InsufficientFundsException(string.Format(HouseCanNotBuildStructure, controllingHouse.Name, structureName));
            }

            controllingHouse.TreasuryAmount -= structureCost;
            city.AddArmyStructure(structure);

            this.Engine.Render("Successfully built {0} in {1}", structureName, cityName);
        }
    }
}

