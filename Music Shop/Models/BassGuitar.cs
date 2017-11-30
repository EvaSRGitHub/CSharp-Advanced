using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    public class BassGuitar : Guitar, IBassGuitar
    {
        private const int BassGuitarNumberOfStrings = 4;

        public BassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerBoardWood) : base(make, model, price, color, bodyWood, fingerBoardWood)
        {
            this.IsElectronic = true;
            this.NumberOfStrings = BassGuitarNumberOfStrings;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
