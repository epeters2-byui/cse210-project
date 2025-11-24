using System;
using System.Collections.Generic;
using System.Linq;


// Represents a full scripture: a Reference and a list of Word objects.
// Responsible for displaying the scripture and hiding words.

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _rng = new Random();

    // Constructor to create Scripture for reference and full text
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split spaces to preserve tokens,keeps desired punctuation attached to words
        
        var tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var t in tokens)
        {
            _words.Add(new Word(t));
        }
    }

    // Display the scripture reference and text by hidding words shown as underscores.
    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        Console.WriteLine();

        // This reconstruct the text with spaces between tokens
        var displayed = string.Join(" ", _words.Select(w => w.Display()));
        Console.WriteLine(displayed);
        Console.WriteLine();
    }

    // True is returned when all words are hidden
    public bool IsFullyHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    // Hide up to 'count' random words. 
    // Returns actual number of newly hidden words.
    public int HideRandomWords(int count)
    {
        var unhidden = _words.Where(w => !w.IsHidden).ToList();
        if (unhidden.Count == 0) return 0;

        // Add available and hide all
        int toHide = Math.Min(count, unhidden.Count);

        // Randomly Select toHide randomlt to distinct indices from unhidden
        for (int i = 0; i < toHide; i++)
        {
            int idx = _rng.Next(unhidden.Count);
            unhidden[idx].Hide();
            // remove chosen from local list so we don't pick it again
            unhidden.RemoveAt(idx);
        }

        return toHide;
    }

    // Total number of words and number of hidden words (display)
    public int TotalWords => _words.Count;
    public int HiddenWords => _words.Count(w => w.IsHidden);
}
