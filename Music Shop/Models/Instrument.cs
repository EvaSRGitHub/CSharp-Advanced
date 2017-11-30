using System;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public abstract class Instrument : Article, IInstrument
    {
        private string color;

        protected Instrument(string make, string model, decimal price,string color) : base(make,model, price)
        {
            this.Color = color;
        }
        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The color is required.");
                }
                this.color = value;
            }
        }

        public bool IsElectronic { get;  protected set; }

        public override string ToString()
        {
            string electric = this.IsElectronic == true ? "yes" : "no";
         
            return base.ToString() + $"{Environment.NewLine}Color: {this.Color}{Environment.NewLine}Electronic: {electric}";  
        }
    }
}
