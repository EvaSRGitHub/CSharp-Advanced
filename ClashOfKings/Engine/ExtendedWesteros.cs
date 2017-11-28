using System;
using System.Collections.Generic;
using System.Linq;
using ClashOfKings.Models;

namespace ClashOfKings.Engine
{
    public class ExtendedWesteros : Westeros
    {
        public ExtendedWesteros() : base() { }

        public override void Update()
        {
            base.Update();
            var upGradeHouses = Houses.Where(h => h.GetType().Name.Equals("House") && h.ControlledCities.Count() >= 10).ToList();
            foreach (var house in upGradeHouses)
            {
                var ToupGrade = Houses.Where(h => h.Name.Equals(house.Name)).First();
                var upGrade = new GreatHouse(ToupGrade.Name, ToupGrade.TreasuryAmount, ToupGrade.ControlledCities);
                Houses.Add(upGrade);
                Houses.Remove(ToupGrade);
            }

            var downGradeHouses = Houses.Where(h => h.GetType().Name.Equals("GreatHouse") && h.ControlledCities.Count() < 5).ToList();

            foreach (var house in downGradeHouses)
            {
                var TodownGrade = Houses.Where(h => h.Name.Equals(house.Name)).First();
                var downGrade = new House(TodownGrade.Name, TodownGrade.TreasuryAmount);
                foreach (var item in TodownGrade.ControlledCities)
                {
                    downGrade.AddCityToHouse(item);
                }
                Houses.Add(downGrade);
                Houses.Remove(TodownGrade);

            }
        }
    }
}
