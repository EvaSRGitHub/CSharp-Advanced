using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private const int ElectricGuitarNumberOfStrings = 6;
        private int numberOfAdapters;
        private int numberOfFrets;
       

        public ElectricGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerBoardWood, int adapters, int frets) : base(make, model, price, color, bodyWood, fingerBoardWood)
        {
            this.NumberOfAdapters = adapters;
            this.NumberOfFrets = frets;
            this.NumberOfStrings = ElectricGuitarNumberOfStrings;
            this.IsElectronic = true;
        }

        public int NumberOfAdapters
        {
            get
            {
               return this.numberOfAdapters;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentNullException("The adapters must be positive.");
                }
                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get
            {
                return this.numberOfFrets;
            }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentNullException("The frets must be positive.");
                }
                this.numberOfFrets = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Adapters: {this.NumberOfAdapters}{Environment.NewLine}Frets: {this.NumberOfFrets}";
        }

    }
}
