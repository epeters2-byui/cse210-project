using System;

// This represent:
// scripture reference like "John 3:16" or "Proverbs 3:5-6".
// multiple constructors (single verse and range).

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    private bool _isRange;

    // Constructor: book, chapter and verse 
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
        _isRange = false;
    }

    // Constructor for book, chapter, starverse and endverse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
        _isRange = startVerse != endVerse;
    }

    public override string ToString()
    {
        if (_isRange)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
    }
}
