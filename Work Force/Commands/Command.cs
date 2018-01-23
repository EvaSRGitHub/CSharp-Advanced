using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public abstract class Command
    {
        private string[] args;
        private Engine engine;

        protected Command(string[] args, Engine engine)
        {
            this.args = args;
            this.engine = engine;
        }

        protected Engine Engine { get { return this.engine; } }
        protected string[] Args { get { return this.args; } }

        public abstract void Execute();
    }
}
