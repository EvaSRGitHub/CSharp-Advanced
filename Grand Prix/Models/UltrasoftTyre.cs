using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; }

    public override double Degradation
    {
        get{return base.Degradation;}

        protected set
        {
            if(value < 30)
            {throw new ArgumentException("Blown Tyre");}
            base.Degradation = value;
        }
    }

    public override void ChangeDegradation()
    {
        base.ChangeDegradation();
        this.Degradation-= this.Grip;
    }
}

