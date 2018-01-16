namespace _02.Blobs
{
    public class Program
    {
        public static void Main()
        {
            ConsoleReaderAndWriter console = new ConsoleReaderAndWriter();
            CommandFactory createCommand = new CommandFactory();
            BehaviorFactory createBehavior = new BehaviorFactory();
            AttackFactory createAttack = new AttackFactory();

            Engine engine = new Engine(console, createCommand, createBehavior, createAttack);
            engine.Run();

        }
    }
}
