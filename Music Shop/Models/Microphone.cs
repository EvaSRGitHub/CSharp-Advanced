using System;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class Microphone : Article, IMicrophone
    {
        public Microphone(string make, string model, decimal price, bool hasCable): base(make, model, price)
        {
            this.HasCable = hasCable;
        }

        public bool HasCable
        {
            get;
        }

        public override string ToString()
        {
            string hasCable = this.HasCable == true ? "yes" : "no";

            return $"= {this.Make} {this.Model} ={Environment.NewLine}Price: ${this.Price:f2}{Environment.NewLine}Cable: {hasCable}";
        }
    }
}
