using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public abstract class Unit : IUnit, IEquatable<IUnit>
    {
        private int defensePOints;
        private int energyPoints;
        private int healthPoints;
        private string name;
        private int range;
        private int x;
        private int y;

        protected Unit(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }

        public int AttackPoints { get; set; }

        public ICombatHandler CombatHandler { get; protected set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public int HealthPoints{get; set;}

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name can't be missing.");
                }
                this.name = value;
            }
        }

        public int Range { get; protected set; }

        public int X { get; set; }

        public int Y { get; set; }

        public bool Equals(IUnit other)
        {
            return this.Name != other.Name;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if(this.HealthPoints > 0)
            {
                sb.AppendLine($">{this.Name} - {this.GetType().Name} at ({this.X},{this.Y})");
                sb.AppendLine($"-Health points = {this.HealthPoints}");
                sb.AppendLine($"-Attack points = {this.AttackPoints}");
                sb.AppendLine($"-Defense points = {this.DefensePoints}");
                sb.AppendLine($"-Energy points = {this.EnergyPoints}");
                sb.Append($"-Range = {this.Range}");
            }
            else
            {
                sb.AppendLine($">{this.Name} - {this.GetType().Name} at ({this.X},{this.Y})");
                sb.Append("(Dead)");
            }
            return sb.ToString();
        }
    }
}
