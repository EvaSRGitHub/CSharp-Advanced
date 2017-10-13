using System;

public class Engine
{
    public Engine()
    {
        this.CommandManager = new CommandManager(this);
        this.DriverFactory = new DriverFactory();
        this.TyreFactory = new TyreFactory();
        this.RaceTower = new RaceTower(this);
        this.HasLapsFinished = false;
    }

    public CommandManager CommandManager { get; }

    public DriverFactory DriverFactory { get; }

    public TyreFactory TyreFactory { get;  }

    public bool HasLapsFinished { get; set; }

    public RaceTower RaceTower { get; }

    public void SetTrack()
    {
        int lapsNumber = int.Parse(InputReader.ReadLine());

        int trackLength = int.Parse(InputReader.ReadLine());

        this.RaceTower.SetTrackInfo(lapsNumber, trackLength);
    }

    public void Run()
    {
         while (this.HasLapsFinished == false)
        {
            string input = InputReader.ReadLine();
            this.CommandManager.ParseCommand(input);
        }
    }
}

