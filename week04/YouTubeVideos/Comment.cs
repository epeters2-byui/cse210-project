public class Comment
{
    // Main variables
    private string _commenterName;
    private string _commentText;

    // the constructor
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    // Method for displaying comment(s)
    public void DisplayComment()
    {
        Console.WriteLine($"  - {_commenterName}: \"{_commentText}\"");
    }
}