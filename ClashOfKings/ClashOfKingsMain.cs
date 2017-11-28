namespace ClashOfKings
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using ClashOfKings.Contracts;
    using ClashOfKings.Engine;
    using ClashOfKings.Engine.Factories;
    using ClashOfKings.UI;
    using System;
    using System.Runtime.Remoting.Messaging;

    public class ClashOfKingsMain
    {
        public static void Main()
        {
          
            string root = @"C:\Users\HOME\Desktop\ClashOfKings-Author";
            var files = Directory.GetFiles(root, "*.cs", SearchOption.AllDirectories);
            StringBuilder sb = new StringBuilder();

            using (StreamWriter st = new StreamWriter(@"../output.txt", true))
            {
                foreach (string file in files)
                {
                    string contents = File.ReadAllText(file);
                    //sb.AppendLine(contents);
                    st.WriteLine(contents);
                }
            }
            
        
           
            //var singleStr = string.Join(Environment.NewLine, result);
            //Console.WriteLine(singleStr);
            //File.WriteAllText(@"C:\output.txt", singleStr, Encoding.UTF8);

           

            IInputController inputController = new ConsoleInputController();
            IRenderer renderer = new ConsoleRenderer();

            IUnitFactory unitFactory = new UnitFactory();
            IArmyStructureFactory armyStructureFactory = new ArmyStructureFactory();
            ICommandFactory commandFactory = new CommandFactory();

            IContinent westeros = new ExtendedWesteros();

           

            IGameEngine engine = new WarEngine(
                renderer, 
                inputController, 
                unitFactory, 
                armyStructureFactory, 
                commandFactory, 
                westeros);

            engine.Run();
        }
    }
}