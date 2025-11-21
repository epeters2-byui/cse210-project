using System;

class Program
{
    static void Main(string[] args)
    {
        // We create main program objects
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        while (true)
        {
            //  menu options are display
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file (JSON)");
            Console.WriteLine("4. Load journal from file (JSON, replaces current)");
            Console.WriteLine("5. Add a custom prompt");
            Console.WriteLine("6. Show all prompts");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option (1-7): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            // OPTION 1: Add a new entry
            if (choice == "1")
            {
                // Get a random prompt
                string prompt = generator.GetRandomPrompt();
                Console.WriteLine("Prompt: " + prompt);

                // Read user's response
                Console.Write("Your response: ");
                string response = Console.ReadLine();
                if (response == null) response = "";

                // Ask for mood
                Console.Write("How are you feeling today (mood)? ");
                string mood = Console.ReadLine();
                if (mood == null) mood = "";

                // Creat and add to journal
                Entry entry = new Entry(prompt, response, mood);
                journal.AddEntry(entry);

                Console.WriteLine("Entry added.");
            }
            // Second option will display entries
            else if (choice == "2")
            {
                journal.Display();
            }
            // Option three wil save journal to JSON file
            else if (choice == "3")
            {
                Console.Write("Enter filename to save (e.g., journal.json): ");
                string filename = Console.ReadLine();

                try
                {
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved to '" + filename + "'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving file: " + ex.Message);
                }
            }
            // The forth option will load journal from JSON file (replace current)
            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();

                try
                {
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded from '" + filename + "'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading file: " + ex.Message);
                }
            }
            // Option five adds a custom prompt
            else if (choice == "5")
            {
                Console.Write("Enter a new prompt to add: ");
                string newPrompt = Console.ReadLine();
                generator.AddPrompt(newPrompt);
                Console.WriteLine("Prompt added.");
            }
            // Option six shows all prompts
            else if (choice == "6")
            {
                int i = 1;
                foreach (string p in generator.GetAllPrompts())
                {
                    Console.WriteLine(i + ". " + p);
                    i++;
                }
            }
            // Seventh option will exit program
            else if (choice == "7")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            // Input is not
            else
            {
                Console.WriteLine("Invalid option. Please enter a number from 1 to 7.");
            }
        }
    }
}
