using System;

public abstract class Driver
{
    protected Driver(string name, Car car)
    {
        this.TotalTime = 0;
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = 0;
    }

    public string Name { get; }

    public Car Car { get; }

    public double TotalTime { get; protected set; }

    public virtual double Speed
    {
        get { return (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount; }
    }

    public double FuelConsumptionPerKm { get; protected set; }

    public void IncreaseTime(double interval)
    {
        this.TotalTime += interval;
    }
    
    public void DecreaseTime(double interval)
    {
        this.TotalTime -= interval;
    }

    public void IncreaseTotalTime(int trackLength)
    {
        this.TotalTime += (60 / (trackLength / this.Speed));
    }
}


