using System;

public class DriverFactory
{
    public Driver CreateDriver(string type, string name, Car car)
    {
        if(type == "Aggressive")
        {
            return new AggressiveDriver(name,car);
        }
        else if(type == "Endurance")
        {
            return new EnduranceDriver(name,car);
        }

        return null;
    }
}


