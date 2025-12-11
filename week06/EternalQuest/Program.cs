// Creativity for Leveling system, Badges, and optional Streaks implemented.
using System;

public class Program
{
    private static GoalManager _manager = new GoalManager();
    private const string _saveFile = "eternalquest_save.txt";

    public static void Main()
    {
        Console.WriteLine("Eternal Quest Program Project");

        //This area auto-load saved progress if file exists
        if (System.IO.File.Exists(_saveFile)) _manager.LoadFromFile(_saveFile);

        bool running = true;
        while (running)
        {
            ShowMenu(); // Present menu including current score
            string choice = ReadNonEmptyString("Select a choice from the menu: ");

            switch (choice)
            {
                case "1": CreateGoalFlow(); break;
                case "2": _manager.DisplayGoals(); break;
                case "3": RecordEventFlow(); break;
                case "4": _manager.SaveToFile(_saveFile); break;
                case "5": _manager.LoadFromFile(_saveFile); break;
                case "6": _manager.ShowScoreAndBadges(); break;
                case "7": running = false; break;
                default: Console.WriteLine("Invalid selection."); break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        Console.WriteLine("Goodbye for Now! Progress saved.");
        _manager.SaveToFile(_saveFile);
    }

    private static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine($"Your current score: {_manager.TotalScore} pts | Level: {_manager.Level}\n");
        Console.WriteLine("Menu Options");
        Console.WriteLine("1. Create new goal");
        Console.WriteLine("2. Show goals");
        Console.WriteLine("3. Record an event");
        Console.WriteLine("4. Save progress");
        Console.WriteLine("5. Load progress");
        Console.WriteLine("6. Show score & badges");
        Console.WriteLine("7. Quit");
        Console.WriteLine();
    }

    private static void CreateGoalFlow()
    {
        Console.WriteLine("The type of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string type = ReadNonEmptyString("Which type of goals would you like to create:?");
        string name = ReadNonEmptyString("What is the name of your goal:? ");
        string description = ReadNonEmptyString("What is the short description of your goal:? ");
        int points = ReadPositiveInt("What is the amount of points associated with this goal:? ");

        if (type == "1")
        {
            _manager.AddGoal(new SimpleGoal(name, description, points));
            Console.WriteLine($"Simple goal '{name}' created.");
        }
        else if (type == "2")
        {
            _manager.AddGoal(new EternalGoal(name, description, points));
            Console.WriteLine($"Eternal goal '{name}' created.");
        }
        else if (type == "3")
        {
            int target = ReadPositiveInt("Target count (times required): ");
            int bonus = ReadNonNegativeInt("Bonus points on completion: ");
            _manager.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
            Console.WriteLine($"Checklist goal '{name}' created (target {target}, bonus {bonus}).");
        }
        else Console.WriteLine("Invalid type.");
    }

    private static void RecordEventFlow()
    {
        _manager.DisplayGoals();
        if (_manager.Goals.Count == 0) return;

        int selection = ReadNonNegativeInt("Enter goal number to record (0 cancel): ");
        if (selection == 0) return;

        _manager.RecordGoalEvent(selection);
    }

    // Code use input helpers
    private static string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(input)) return input.Trim();
            Console.WriteLine("Input cannot be empty.");
        }
    }

    private static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int val) && val > 0) return val;
            Console.WriteLine("Enter a positive integer.");
        }
    }

    private static int ReadNonNegativeInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int val) && val >= 0) return val;
            Console.WriteLine("Enter 0 or a positive integer.");
        }
    }
}
