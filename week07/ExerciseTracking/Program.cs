using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Exercise Tracking Program");
        Console.WriteLine("=========================\n");
        
        // Create a list to hold all activities (demonstrating polymorphism)
        List<Activity> activities = new List<Activity>();
        
        // Create different activities
        Running running = new Running(new DateTime(2025, 11, 15), 30, 3.0);
        Cycling cycling = new Cycling(new DateTime(2025, 11, 16), 45, 15.0);
        Swimming swimming = new Swimming(new DateTime(2025, 11, 17), 60, 40);
        
        // Add activities to the list
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);
        
        // Add additional activities 
        activities.Add(new Running(new DateTime(2025, 12, 6), 45, 4.5));
        activities.Add(new Cycling(new DateTime(2025, 12, 7), 60, 18.0));
        activities.Add(new Swimming(new DateTime(2025, 12, 8), 30, 20));
        
        // Each activity's summary displays
        // Demonstrates polymorphism
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
        
        Console.WriteLine("\nExercise tracking complete!");
    }
}