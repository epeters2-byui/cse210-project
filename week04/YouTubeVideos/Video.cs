using System;
using System.Collections.Generic;

public class Video
{
    // The main variables
    private string _title;
    private string _author;
    private int _length; // place in seconds
    private List<Comment> _comments;

    // the constructor for title, author, length
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // Method for adding comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method for returning the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Video information and all comments method todisplay
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        
        foreach (Comment comment in _comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine("=====================================");
        Console.WriteLine();
    }
}