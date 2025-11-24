using System.Text.RegularExpressions;

// For a single word or token in the scripture text.

public class Word
{
    private string _original;   //For original token and punctuation
    private bool _hidden;

    public Word(string token)
    {
        _original = token;
        _hidden = false;
    }

    // Public read-only property to ask word is hidden
    public bool IsHidden => _hidden;

    // Hide this word/marks hidden
    public void Hide()
    {
        _hidden = true;
    }

    // Return either original token or underscores matching letters, keeping punctuation.
    public string Display()
    {
        if (!_hidden)
        {
            return _original;
        }
        // letters are replaced with underscores but keep punctuation.
        // We use regex to replace [A-Za-z] with '_'
        return Regex.Replace(_original, "[A-Za-z]", "_");
    }

    // Show original, keep read-only for any comparison if needed 
    public string Original => _original;
}
