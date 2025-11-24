using System;
using System.Collections.Generic;

// A small library of scriptures to choose from. 

public class ScriptureLibrary
{
    private List<Scripture> _library = new List<Scripture>();
    private Random _rng = new Random();

    public ScriptureLibrary()
    {
        // Populate with several sample scriptures
        
        Add("John", 3, 16, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        Add("Mosiah", 12, 27, "Ye have not applied your hearts to understainding; therefore, ye have not been wise. therefore, what teach ye this people?");
        AddRange("Jacob", 6, 12,13, "O be wise; what can I say more? Finally, I bid you farewell, until I shall meet you before the pleasing bar of God, which bar striketh the wicked with awful dread and fear. Amen");
        Add("2 Nephi", 33, 6, "I glory in plainess; I glory in truth; I glory in my Jesus, for he hath redeemed my soul from hell.");
        Add("Doctrine and Covenants", 130, 19, "And if a person gains more knowledge and intelligence in this life through his diligence and obedience than another, he will have so much the advantage in the world to come.");
    }

    // Add single-verse scripture
    private void Add(string book, int chapter, int verse, string text)
    {
        var reference = new Reference(book, chapter, verse);
        _library.Add(new Scripture(reference, text));
    }

    // Add verse-range scripture
    private void AddRange(string book, int chapter, int startVerse, int endVerse, string text)
    {
        var reference = new Reference(book, chapter, startVerse, endVerse);
        _library.Add(new Scripture(reference, text));
    }

    // Get a random scripture from the library.
    public Scripture GetRandomScripture()
    {
        int idx = _rng.Next(_library.Count);
        var template = _library[idx];

        return template;
    }
}
