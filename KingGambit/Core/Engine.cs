using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsGambit
{
    public class Engine
    {
        private ConsoleReaderAndWriter console;
        private UnitFactory unitFactory;
        private Dictionary<string, IUnit> killableUnits;
        private IUnit king;

        public Engine(ConsoleReaderAndWriter console, UnitFactory unitFactory)
        {
            this.console = console;
            this.unitFactory = unitFactory;
            this.killableUnits = new Dictionary<string, IUnit>();
        }

        public void Run()
        {
            string[] kingName = this.console.Reader().Split();
            CreateKillableUnitAndAddItToCollection(kingName, typeof(King));
            //this.king = new King(kingName);

            string[] royalGuardsNames = this.console.Reader().Split();
            CreateKillableUnitAndAddItToCollection(royalGuardsNames, typeof(RoyalGuard));

            string[] footmansNames = this.console.Reader().Split();
            CreateKillableUnitAndAddItToCollection(footmansNames, typeof(Footman));

            string command;
            while ((command = this.console.Reader())!= "End")
            {
                ExecuteCommand(command);
            }

        }

        private void ExecuteCommand(string command)
        {
            string[] args = command.Split();

            switch (args[0])
            {
                case "Attack":
                    IAttackable king = this.killableUnits.Values.Where(u => u.GetType().Name == "King") as IAttackable;

                    foreach (var unit in this.killableUnits)
                    {
                        (unit.Value as IRactToEvent).ReactToKingBeengAttacked(king);
                    }
                    king.RespondToAttack();
                    break;

                case "Kill":
                    this.killableUnits.Remove(args[1]);
                    break;

                default:
                    throw new InvalidOperationException("Unknown command!");
            }
        }

        private void CreateKillableUnitAndAddItToCollection(string[] unitNames, Type unitType)
        {
            foreach (var royalName in unitNames)
            {

                IUnit unit = this.unitFactory.Create(royalName, unitType);

                this.killableUnits.Add(royalName, unit);
            }
        }
    }
}
