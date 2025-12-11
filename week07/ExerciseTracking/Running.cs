public class Running : Activity
{
    // Private member variable for Running
    private double _distance; // in miles
    
    // Constructor for Running activity
    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }
    
    // This override abstract methods from base class
    public override double GetDistance()
    {
        return _distance;
    }
    
    public override double GetSpeed()
    {
        // Speed = (distance / minutes) * 60
        return (_distance / GetLengthInMinutes()) * 60;
    }
    
    public override double GetPace()
    {
        // Pace = minutes / distance
        return GetLengthInMinutes() / _distance;
    }
    
    // This override GetSummary to provide Running-specific information
    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {GetDistance():F1} miles, " +
               $"Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}