using System;
using System.Collections.Generic;

// Provides a set of prompts and returns one at random.
public class PromptGenerator
{
    // List of prompts to show to the user
    private List<string> _prompts = new List<string>();

    // Random object for selecting prompts
    private Random _rand = new Random();

    // Constructor: initialize 10 prompts (including the required ones)
    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What am I most grateful for today?");
        _prompts.Add("What challenges did I face today, and how did I respond to them?");
        _prompts.Add("What is one thing I learned today?");
        _prompts.Add("How did I show kindness today?");
        _prompts.Add("What is one thing I want to improve tomorrow?");
    }

    // Return a random prompt from the list
    public string GetRandomPrompt()
    {
        int index = _rand.Next(0, _prompts.Count);
        return _prompts[index];
    }

    // Add a custom prompt to the list at runtime (ignores empty or null inputs)
    public void AddPrompt(string prompt)
    {
        if (prompt != null && prompt.Trim() != "")
        {
            _prompts.Add(prompt.Trim());
        }
    }

    // Return a copy of all prompts (read-only)
    public List<string> GetAllPrompts()
    {
        return new List<string>(_prompts);
    }
}
