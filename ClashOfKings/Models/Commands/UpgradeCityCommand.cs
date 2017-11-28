using System;
using ClashOfKings.Attributes;
using ClashOfKings.Contracts;
using ClashOfKings.Exceptions;

namespace ClashOfKings.Models.Commands
{
    [Command]
    public class UpgradeCityCommand : Command
    {
        public UpgradeCityCommand(IGameEngine engine) : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            string cityToUpgrade = commandParams[0];

            ICity city = this.Engine.Continent.GetCityByName(cityToUpgrade);
            if (city == null)
            {
                throw new NonExistentCityException($"{cityToUpgrade} doesn't exist.");
            }

            var controllingHouse = city.ControllingHouse;
            controllingHouse.UpgradeCity(city);

            this.Engine.Render($"City {cityToUpgrade} successfully upgraded to {city.CityType}");
        }
    }
}
