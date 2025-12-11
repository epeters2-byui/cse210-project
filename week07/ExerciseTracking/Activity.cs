using System;

public abstract class Activity
{
    // This provide private member variables for encapsulation
    private DateTime _date;
    private int _lengthInMinutes;
    
    // Constructor for Activity base class
    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }
    
    // Protected getters for derived classes to access private data
    protected DateTime GetDate() => _date;
    protected int GetLengthInMinutes() => _lengthInMinutes;
    
    // Abstract methods derived classes MUST implement these
    // This is where polymorphism is defined
    public abstract double GetDistance();  // In miles
    public abstract double GetSpeed();     // In mph
    public abstract double GetPace();      // In minutes per mile
    
    // Summary of the activity
    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_lengthInMinutes} min)";
    }
}