using System;
using ClashOfKings.Attributes;
using ClashOfKings.Contracts;
using ClashOfKings.Exceptions;

namespace ClashOfKings.Models.Commands
{
    [Command]
    public class AddNeighborsToCityCommand : Command
    {
        private const string NonExistentCity = "The city of {0} doesn't exist.";
        private const string NonExistentNeighbor = "Specified neighbor does not exist";
        private const string NegativeDistance = "The distance between cities cannot be negative";

        public AddNeighborsToCityCommand(IGameEngine engine) : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            string destiniationCityName = commandParams[0];
            ICity destinationCity = this.Engine.Continent.GetCityByName(destiniationCityName);

            if(destinationCity == null)
            {
                throw new NonExistentCityException(string.Format(NonExistentCity, destiniationCityName));
            }

            for (int i = 1; i < commandParams.Length-1; i+=2)
            {
                string neghboringCityName = commandParams[i];
                ICity neghboringCity = this.Engine.Continent.GetCityByName(neghboringCityName);

               if(neghboringCity == null)
                {
                    throw new NonExistentCityException(string.Format(NonExistentNeighbor));
                }

                double distance = double.Parse(commandParams[i + 1]);
                if(distance < 0)
                { throw new LocationOutOfRangeException(NegativeDistance); }

                if (!this.Engine.Continent.CityNeighborsAndDistances[destinationCity].ContainsKey(neghboringCity))
                {
                    this.Engine.Continent.CityNeighborsAndDistances[destinationCity].Add(neghboringCity, distance);
                }

                if (!this.Engine.Continent.CityNeighborsAndDistances[neghboringCity].ContainsKey(destinationCity))
                {
                    this.Engine.Continent.CityNeighborsAndDistances[neghboringCity].Add(destinationCity, distance);
                }

                this.Engine.Render($"All valid neighbor records added for city {destiniationCityName}");
            }
        }
    }
}
