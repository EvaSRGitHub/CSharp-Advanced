using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    public abstract class Guitar : Instrument, IGuitar
    {
        private string bodyWood;
        private string fingerBoardWood;

        protected Guitar(string make, string model, decimal price, string color, string bodyWood, string fingerBoardWood) : base(make, model, price, color)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerBoardWood;
        }

        public string BodyWood
        {
            get { return this.bodyWood; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The body is required.");
                }
                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get { return this.fingerBoardWood; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The fingerboard is required.");
                }
                this.fingerBoardWood = value;
            }
        }

        public int NumberOfStrings
        { get; protected set; }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Strings: {this.NumberOfStrings}{Environment.NewLine}Body wood: {this.BodyWood}{Environment.NewLine}Fingerboard wood: {this.FingerboardWood}";
        }
    }
}
