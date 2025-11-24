using System;

// Program will do the below as creativity: 
// Added a ScriptureLibrary class to pick scriptures at random instead of hard-coding a single one.
// Hiding logic avoids re-hiding already-hidden words (stretch feature).
// Hides up to 3 words per Enter (scales down when fewer words remain).
// Displays progress (percentage hidden) to help the user track memory progress.
// loading scriptures from files and saving user progress.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Scripture Memorizer");
        Console.WriteLine(" ");
        Console.WriteLine("Press Enter to hide some words. Type 'quit' and press Enter to exit.");
        Console.WriteLine();

        // library and choose  scripture
        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        // important loop for the program
        while (true)
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine($"Progress: {scripture.HiddenWords}/{scripture.TotalWords} words hidden ({PercentHidden(scripture):F1}%)");
            if (scripture.IsFullyHidden())
            {
                Console.WriteLine("All words are hidden. Good job! Program will now exit.");
                break;
            }

            Console.WriteLine("Press Enter to hide more words, or type 'quit' and press Enter to exit.");
            string input = Console.ReadLine().Trim();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            // Decide number of words to hide this step:
            // Hide up to 3 words each press, but not more than remaining.
            int remaining = scripture.TotalWords - scripture.HiddenWords;
            int hideCount = Math.Min(3, Math.Max(1, remaining / 6)); // scale: about 1/6 of remaining but at least 1, up to 3
            
            // Ensure at least one word hidden per step; fallback to 1 if computed 0
            if (hideCount <= 0) hideCount = 1;
            hideCount = Math.Min(hideCount, 3);
            hideCount = Math.Min(hideCount, remaining);

            scripture.HideRandomWords(hideCount);
            // Loop clear at start of next iteration
        }

        // Last pause so user can see the final display
        Console.WriteLine();
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    static double PercentHidden(Scripture s)
    {
        if (s.TotalWords == 0) return 100.0;
        return (double)s.HiddenWords / s.TotalWords * 100.0;
    }
}
