using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public class Engine
    {
        private List<IBlob> blobs;
        private ConsoleReaderAndWriter console;
        private CommandFactory createCommand;
        private BehaviorFactory createBehavior;
        private AttackFactory createAttack;

        public Engine(ConsoleReaderAndWriter console, CommandFactory createCommand, BehaviorFactory createBehavior, AttackFactory createAttack)
        {
            this.console = console;
            this.createCommand = createCommand;
            this.createBehavior = createBehavior;
            this.createAttack = createAttack;
            this.blobs = new List<IBlob>();
        }

        public IEnumerable<IBlob> Blobs
        {
            get { return this.blobs; }
        }

        public ConsoleReaderAndWriter Console { get { return this.console; } }

        public BehaviorFactory CreateBehavior { get { return this.createBehavior; } }

        public AttackFactory CreateAttack { get { return this.createAttack; } }

        public void AddBlob(IBlob blob)
        {
            this.blobs.Add(blob);
        }

        public void Run()
        {
            while (true)
            {
                string[] args = this.Console.Reader().Split();

                ICommand command = this.createCommand.Create(this, args);

                ApplyBehaviorEffect();

                command.Execute();
            }
        }

        private void ApplyBehaviorEffect()
        {
            foreach (var blob in this.Blobs)
            {
                blob.TryToApplayBehaviorEffect(blob);
            }
        }
    }
}
