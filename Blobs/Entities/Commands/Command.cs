using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs
{
    public abstract class Command : ICommand
    {
        private Engine engine;
        private string[] args;

        protected Command(Engine engine, string [] args)
        {
            this.engine = engine;
            this.args = args;
        }

        public string[] Args { get { return this.args; } }

        public Engine Engine { get { return this.engine; } }

        public abstract void Execute();
    }
}
