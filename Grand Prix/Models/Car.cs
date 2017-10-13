using System;

public class Car
{
    private const double MaxFuelCapacity = 160;

    private double fuel;

    public Car()
    {

    }

    public Car(int hp, double fuel, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuel;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get { return this.fuel; }
        private set
        {
            if (value < 0)
            { throw new ArgumentException("Out of fuel"); }

            if (value > MaxFuelCapacity)
            { this.fuel = MaxFuelCapacity; }
            else
            { this.fuel = value; }
        }
    }

    public Tyre Tyre { get; private set; }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void ReduceFuel(int trackLength, double fuelConsuptionPerKm)
    {
        this.FuelAmount -= (trackLength * fuelConsuptionPerKm);
    }

    public void Refuel(double refuelAmount)
    {
        this.FuelAmount += refuelAmount;
    }
}

