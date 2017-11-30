using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
   

    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        private const int AcousticGuitarNumberOfStrings = 6;

        public AcousticGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerBoardWood, bool caseIncluded, StringMaterial stringType) : base(make, model, price, color, bodyWood, fingerBoardWood)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringType;
            this.IsElectronic = false;
            this.NumberOfStrings = AcousticGuitarNumberOfStrings;
        }

        public bool CaseIncluded
        { get; private set; }

        public StringMaterial StringMaterial
        { get; private set; }

        public override string ToString()
        {
            string caseIncluded = this.CaseIncluded == true ? "yes" : "no";

            return base.ToString() + $"{Environment.NewLine}Case included: {caseIncluded}{Environment.NewLine}String material: {this.StringMaterial.ToString()}";
        }
    }
}
