using System;
using System.Collections.Generic;
using System.Threading;

// Inherits from Activity base class
// Inheritance demostrated while providing listing-specific functionality
public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _itemCount;
    
    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    )
    {
        // This initializes listing-specific data
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What some weaknesses about yourself?",
            "What do you like to do best over the weekend?",
            "Where are your favorite places?",
        };
    }
    
    // The abstract method with listing-specific behavior are implemented
    public override void Run()
    {
        // Use base class common functionality
        DisplayStartingMessage();
        
        // Listing-specific logic
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(5); // inherited countdown method
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        _itemCount = 0;
        
        //User's input collected until time expires
        Console.WriteLine("Start listing now:");
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                _itemCount++;
            }
        }
        
        // Listing-specific result display
        Console.WriteLine();
        Console.WriteLine($"You listed {_itemCount} items!");
        
        // Use base class common functionality
        DisplayEndingMessage();
    }
}