using System;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class Drum : Instrument,IDrums
    {
        private int width;
        private int height;

        public Drum(string make, string model, decimal price, string color, int width, int height) : base(make, model, price, color)
        {
            this.Width = width;
            this.Height = height;
            this.IsElectronic = false;
        }

        public int Width
        {
            get { return this.width; }
            private set { if(value < 0)
                {
                    throw new ArgumentNullException("Width can't be negative.");
                }
                this.width = value; 
            }
        }

        public int Height
        {
            get { return this.height; }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentNullException("Height can't be negative.");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Size: {this.Width}cm x {this.Height}cm";
        }

    }
}
