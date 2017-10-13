using System;
using System.Collections.Generic;
using System.Linq;

public class CommandManager
{
    public CommandManager(Engine engine)
    {
        this.Engine = engine;
    }
    public Engine Engine { get; }

    public void ParseCommand(string input)
    {
        List<string> commandsArgs = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string command = commandsArgs[0];
        commandsArgs.RemoveAt(0);

        ProcessCommand(command, commandsArgs);
    }

    private void ProcessCommand(string command, List<string> args)
    {
        switch (command)
        {
            case "RegisterDriver":
                this.Engine.RaceTower.RegisterDriver(args);
                break;
            case "Leaderboard":
                OutputWriter.Write(this.Engine.RaceTower.GetLeaderboard());
                break;
            case "CompleteLaps":
             string output = (this.Engine.RaceTower.CompleteLaps(args));
                    if (output != string.Empty) { OutputWriter.WriteLine(output); }
                break;
            case "Box":
                this.Engine.RaceTower.DriverBoxes(args);
                break;
            case "ChangeWeather":
                this.Engine.RaceTower.ChangeWeather(args);
                break;
        }
    }
}


