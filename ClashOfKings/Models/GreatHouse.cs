using System;
using System.Collections.Generic;
using ClashOfKings.Contracts;
using System.Text;

namespace ClashOfKings.Models
{
    public class GreatHouse : House
    {
        private decimal treasuryAmount;

        public GreatHouse(string name, decimal initialTreasuryAmount, IEnumerable<ICity> controlledCities) : base(name, initialTreasuryAmount)
        {
            // Author: bez tova
         this.GreatHouseControlledCities = GetCities(controlledCities);

            AddCities(GreatHouseControlledCities);
            //Author: bez tova
            this.TreasuryAmount = initialTreasuryAmount;
        }

        private void AddCities(IList<ICity> greatHouseCities)
        {
            foreach (var item in greatHouseCities)
            {
                this.AddCityToHouse(item);
            }
        }

        //Author: bez tova
        public IList<ICity> GreatHouseControlledCities { get; private set; }

        //Author: bez tova
        private IList<ICity> GetCities(IEnumerable<ICity> controlledCities)
        {
            IList<ICity> cities = new List<ICity>();
            foreach (var item in controlledCities)
            {
               cities.Add(item);
            }
            return cities;
        }

        // Author: public override decimal TreasuryAmount { get; set; }
        public override decimal TreasuryAmount
        {
            get
            {return this.treasuryAmount;}

            set
            {this.treasuryAmount = value;}
        }

        public override void UpgradeCity(ICity city)
        {
            city.Upgrade();
            this.TreasuryAmount -= city.UpgradeCost;
        }

        //Author: StringBuilder result = new StringBuilder("Great ");
        //result.Append(base.Print());
        public override string Print()
        {
            StringBuilder sb = new StringBuilder(base.Print());
            sb.Replace("House", "Great House");
            return sb.ToString();
        }
    }
}
