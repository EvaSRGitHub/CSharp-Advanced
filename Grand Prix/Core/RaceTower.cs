using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private List<Driver> drivers;

    private Dictionary<Driver, string> stopedDrivers;

    private int trackLaps;

    private int trackLength;

    private int currentLap;

    public RaceTower()
    {

    }

    public RaceTower(Engine engine)
        :this()
    {
        this.drivers = new List<Driver>();
        this.stopedDrivers = new Dictionary<Driver, string>();
        this.Engine = engine;
        this.Wether = "Sunny";
    }

    public Engine Engine { get; }

    public string Wether { get; private set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.trackLaps = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string type = commandArgs[0];
            string name = commandArgs[1];

            int hp = int.Parse(commandArgs[2]);
            double fuel = double.Parse(commandArgs[3]);

            Tyre tyre = Engine.TyreFactory.CreateTyre(commandArgs.Skip(4).ToArray());

            Car car = new Car(hp, fuel, tyre);

            Driver driver = Engine.DriverFactory.CreateDriver(type, name, car);
            if (driver != null)
            {
                this.drivers.Add(driver);
            }
        }
        catch (Exception)
        {
            return;
        }

    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driversName = commandArgs[1];

        var driverAtBox = this.drivers.Where(d => d.Name.Equals(driversName)).First();

        driverAtBox.IncreaseTime(20);

        switch (reasonToBox)
        {
            case "Refuel":
                driverAtBox.Car.Refuel(double.Parse(commandArgs[2]));
                break;

            case "ChangeTyres":
                var data = commandArgs.Skip(2).ToArray();

                var newTyre = Engine.TyreFactory.CreateTyre(data);

                driverAtBox.Car.ChangeTyre(newTyre);
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        string output = string.Empty;

        try
        {
            int numberOfLaps = int.Parse(commandArgs[0]);
            if (numberOfLaps > (this.trackLaps - currentLap))
            {
                throw new ArgumentException($"There is no time! On lap {currentLap}.");
            }
            else
            {
                for(int i = 1; i <= numberOfLaps; i++)
                {
                    currentLap++;

                    Race();

                    RemoveStopedDrivers();

                    bool hasOvertake = false;

                    drivers = drivers.OrderByDescending(d => d.TotalTime).ToList();

                    hasOvertake = OverTake(hasOvertake);
                }
            }
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        if (currentLap == trackLaps)
        {
            output = EditWinner();
        }
        return output;
    }

    private void Race()
    {
        for (int k = 0; k < drivers.Count; k++)
        {
            drivers[k].IncreaseTotalTime(this.trackLength);

            try
            {
                drivers[k].Car.ReduceFuel(this.trackLength, drivers[k].FuelConsumptionPerKm);

                drivers[k].Car.Tyre.ChangeDegradation();
            }
            catch (ArgumentException ae)
            {
                stopedDrivers.Add(drivers[k], ae.Message);
            }
        }
    }

    private string EditWinner()
    {
        string output;
        var winner = drivers.OrderBy(d => d.TotalTime).First();

        output = ($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
        Engine.HasLapsFinished = true;
        Engine.Run();
        return output;
    }

    private bool OverTake(bool hasOvertake)
    {
        for (int j = 0; j < drivers.Count - 1; j++)
        {
            var driverBehind = drivers[j];
            var driverAhead = drivers[j + 1];
            var differenceInTime = driverBehind.TotalTime - driverAhead.TotalTime;

            try
            {
                hasOvertake = TryOvertake(drivers, stopedDrivers, currentLap, driverBehind, driverAhead, differenceInTime);
            }
            catch (ArgumentException ae)
            {
                Crash(drivers, stopedDrivers, driverBehind, ae);
            }

            if (hasOvertake)
            {
                OutputWriter.WriteLine($"{driverBehind.Name} has overtaken {driverAhead.Name} on lap {currentLap}.");
                j++;
            }
        }

        return hasOvertake;
    }

    private void RemoveStopedDrivers()
    {
        foreach (var driver in stopedDrivers)
        {
            if (drivers.Any(d => d.Name == driver.Key.Name))
            {
                drivers.Remove(driver.Key);
            }
        }
    }

    private bool TryOvertake(List<Driver> drivers, Dictionary<Driver, string> stopedDrivers, int currentLap, Driver driverBehind, Driver driverAhead, double differenceInTime)
    {
        bool hasOvertake = false;

        if ((driverBehind.GetType().Name == ("AggressiveDriver")) && (driverBehind.Car.Tyre.GetType().Name.Equals("UltrasoftTyre")) && differenceInTime <= 3)
        {
            if (this.Wether == "Foggy")
            {
                throw new ArgumentException("Crashed");
            }
            else
            {
                Overtake(drivers, driverBehind, driverAhead, 3);

                hasOvertake = true;
            }
        }
        else if ((driverBehind.GetType().Name.Equals("EnduranceDriver")) && (driverBehind.Car.Tyre.GetType().Name.Equals("HardTyre")) && differenceInTime <= 3)
        {
            if (this.Wether == "Rainy")
            {
                throw new ArgumentException("Crashed");
            }
            else
            {
                Overtake(drivers, driverBehind, driverAhead, 3);

                hasOvertake = true;
            }
        }
        else if (differenceInTime <= 2)
        {
            Overtake(drivers, driverBehind, driverAhead, 2);

            hasOvertake = true;
        }

        return hasOvertake;
    }

    private static void Overtake(List<Driver> drivers, Driver driverBehind, Driver driverAhead, double differenceInTime)
    {
        driverBehind.DecreaseTime(differenceInTime);

        driverAhead.IncreaseTime(differenceInTime);
    }

    private static void Crash(List<Driver> drivers, Dictionary<Driver, string> stopedDrivers, Driver driverBehind, ArgumentException ae)
    {
        stopedDrivers.Add(driverBehind, ae.Message);
        drivers.Remove(driverBehind);
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        int position = 1;

        sb.AppendLine($"Lap {this.currentLap}/{this.trackLaps}");

        foreach (var driver in this.drivers.OrderBy(d => d.TotalTime))
        {
            sb.AppendLine($"{position} {driver.Name} {driver.TotalTime:f3}");
            position++;
        }

        foreach (var driver in this.stopedDrivers.Reverse())
        {
            sb.AppendLine($"{position} {driver.Key.Name} {driver.Value}");
            position++;
        }

        return sb.ToString();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.Wether = commandArgs[0];
    }
}

