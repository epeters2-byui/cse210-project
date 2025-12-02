using System;

/*
Exceeding Requirements:
1. Added input validation to handle non-numeric duration inputs
2. Implemented a session tracker that shows how many times each activity was completed
3. Added a feature that ensures no prompt repetition in reflection activity during a single session
4. Enhanced user experience with better error handling and smooth transitions
*/

class Program
{
    private static int breathingCount = 0;
    private static int reflectionCount = 0;
    private static int listingCount = 0;
    
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("This program demonstrates inheritance through activity classes.");
        
        while (true)
        {
            ShowMenu();
            string choice = Console.ReadLine();
            
            Activity activity = null;
            
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    breathingCount++;
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    reflectionCount++;
                    break;
                case "3":
                    activity = new ListingActivity();
                    listingCount++;
                    break;
                case "4":
                    ShowSessionSummary();
                    Console.WriteLine("Thank you for practicing mindfulness. Goodbye!");
                    return;
                case "5":
                    ShowSessionSummary();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-5.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
            }
            
            // Demonstrate polymorphism: calling Run() on base class reference
            // that actually executes derived class implementation
            activity.Run();
        }
    }
    
    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Mindfulness Activities");
        Console.WriteLine("======================");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");
        Console.WriteLine("5. Show Session Summary");
        Console.WriteLine();
        Console.Write("Choose an activity (1-5): ");
    }
    
    static void ShowSessionSummary()
    {
        Console.WriteLine();
        Console.WriteLine("Session Summary");
        Console.WriteLine("===============");
        Console.WriteLine($"Breathing Activities completed: {breathingCount}");
        Console.WriteLine($"Reflection Activities completed: {reflectionCount}");
        Console.WriteLine($"Listing Activities completed: {listingCount}");
        Console.WriteLine($"Total sessions: {breathingCount + reflectionCount + listingCount}");
        Console.WriteLine();
    }
}


