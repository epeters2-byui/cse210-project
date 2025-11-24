using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create video 1
        Video video1 = new Video("C# Programming Tutorial", "CodeMaster", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial! Very helpful for beginners."));
        video1.AddComment(new Comment("Bob", "I learned so much from this video."));
        video1.AddComment(new Comment("Charlie", "Could you make a video on inheritance?"));
        videos.Add(video1);

        // Create video 2
        Video video2 = new Video("ASP.NET Core Web Development", "WebWizard", 1200);
        video2.AddComment(new Comment("Diana", "This changed how I build web apps!"));
        video2.AddComment(new Comment("Eve", "Perfect explanation of middleware."));
        video2.AddComment(new Comment("Frank", "When is the next part coming out?"));
        video2.AddComment(new Comment("Grace", "Loved the real-world examples."));
        videos.Add(video2);

        // Create video 3
        Video video3 = new Video("Entity Framework Basics", "DatabasePro", 900);
        video3.AddComment(new Comment("Henry", "Finally understand EF relationships!"));
        video3.AddComment(new Comment("Ivy", "Clear and concise explanation."));
        video3.AddComment(new Comment("Jack", "This saved me hours of reading documentation."));
        videos.Add(video3);

        // Create video 4
        Video video4 = new Video("Machine Learning with ML.NET", "AIExplorer", 1800);
        video4.AddComment(new Comment("Karen", "Mind-blowing applications!"));
        video4.AddComment(new Comment("Leo", "I implemented this in my project successfully."));
        video4.AddComment(new Comment("Mona", "The code examples were very practical."));
        video4.AddComment(new Comment("Nathan", "Can you cover more advanced topics?"));
        videos.Add(video4);

        // Display all videos and their comments
        Console.WriteLine("YouTube Video Analysis");
        Console.WriteLine("======================");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}