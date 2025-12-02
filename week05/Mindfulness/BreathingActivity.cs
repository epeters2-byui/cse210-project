using System;
using System.Threading;

// Inherits from Activity base class
// Shows inheritance by using base class functionality while adding specific behavior
public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    ) { }
    
    // This implements the abstract method from the base class
    // Specific breathing exercise behavior provided
    public override void Run()
    {
        // Base class method used for common setup
        DisplayStartingMessage();
        
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        // Logic for breathing exercise specified
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountdown(4); // inherited countdown method
            
            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountdown(6); // inherited countdown method
            Console.WriteLine();
        }
        
        // Base class method used for common cleanup
        DisplayEndingMessage();
    }
}