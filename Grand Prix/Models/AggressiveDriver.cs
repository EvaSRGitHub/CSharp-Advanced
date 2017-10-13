using System;

public class AggressiveDriver : Driver
{
    private const double AggressiveFuelConsumpsion = 2.7;
    private const double SpeedMulitplicator = 1.3;

    public AggressiveDriver(string name, Car car) : base(name, car)
    {
        this.FuelConsumptionPerKm = AggressiveFuelConsumpsion;
    }
   
    public override double Speed
    {
     get { return base.Speed * SpeedMulitplicator; }
    }

   
}

