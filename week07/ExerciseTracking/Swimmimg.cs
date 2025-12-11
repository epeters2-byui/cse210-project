public class Swimming : Activity
{
    // Private variable for Swimming
    private int _laps;
    
    // Constant for lap length expressed in miles
    private const double LAP_LENGTH_IN_MILES = 60.0 / 1000.0 * 0.62; // meters converted to miles
    
    // Constructor for Swimming activity
    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }
    
    // Abstract methods override from base class
    public override double GetDistance()
    {
        // Distance in miles = laps * 60 meters / 1000 * 0.62
        return _laps * LAP_LENGTH_IN_MILES;
    }
    
    public override double GetSpeed()
    {
        // Speed = (distance / minutes) * 60
        return (GetDistance() / GetLengthInMinutes()) * 60;
    }
    
    public override double GetPace()
    {
        // Pace = minutes / distance
        return GetLengthInMinutes() / GetDistance();
    }
    
    // Override GetSummary to provide Swimming-specific information
    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {GetDistance():F2} miles, " +
               $"Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile, " +
               $"Laps: {_laps}";
    }
}