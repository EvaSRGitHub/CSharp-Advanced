using System;

public abstract class Tyre
{
    private const double DegradationConst = 100;

    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = DegradationConst;
    }

    public string Name { get; }

    public double Hardness { get; }

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if(value < 0)
            { throw new ArgumentException("Blown Tyre"); }
            else { this.degradation = value; }
        }
    }

    public virtual void ChangeDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}
