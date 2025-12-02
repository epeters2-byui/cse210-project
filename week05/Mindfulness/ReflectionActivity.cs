using System;
using System.Collections.Generic;
using System.Threading;

// Inherits from Activity base class
// Inheritance are demostrated while providing reflection-specific functionality
public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    
    public ReflectionActivity() : base(
        "Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    )
    {
        // Initialize reflection-specific data
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you were hungry.",
            "Think of a time when you overwhelmed.",
        };
        
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }
    
    // Implements the abstract method with reflection-specific behavior
    public override void Run()
    {
        // This use base class common functionality
        DisplayStartingMessage();
        
        // Reflection-specific logic
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5); // Use inherited countdown method
        Console.WriteLine();
        Console.Clear();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        // Show reflection questions until time expires
        List<string> availableQuestions = new List<string>(_questions);
        
        while (DateTime.Now < endTime && availableQuestions.Count > 0)
        {
            int index = random.Next(availableQuestions.Count);
            string question = availableQuestions[index];
            availableQuestions.RemoveAt(index);
            
            Console.Write($"> {question} ");
            ShowSpinner(8); // Use inherited spinner method
            Console.WriteLine();
        }
        
        // Use base class common functionality
        DisplayEndingMessage();
    }
}