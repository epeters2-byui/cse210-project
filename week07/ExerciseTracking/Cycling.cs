public class Cycling : Activity
{
    // Private member variable specific to Cycling
    private double _speed; // in mph
    
    // Constructor for Cycling activity
    public Cycling(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }
    
    // Override abstract methods from base class
    public override double GetDistance()
    {
        // Distance = (speed * minutes) / 60
        return (_speed * GetLengthInMinutes()) / 60;
    }
    
    public override double GetSpeed()
    {
        return _speed;
    }
    
    public override double GetPace()
    {
        // Pace = 60 / speed
        return 60 / _speed;
    }
    
    // Override GetSummary to provide Cycling-specific information
    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {GetDistance():F1} miles, " +
               $"Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}