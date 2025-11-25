using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        // Create and add a list to store videos
        List<Video> videos = new List<Video>();

        // Add video 1
        Video video1 = new Video("New mobile service", "LibTelco", 700);
        video1.AddComment(new Comment("Flomo", "Great Mobile service! Very helpful for High school students."));
        video1.AddComment(new Comment("Kumba", "I learned so much using the mobile serive video."));
        video1.AddComment(new Comment("Papey", "Could this mobile service reach rural communities?"));
        videos.Add(video1);

        // Bring video 2
        Video video2 = new Video("Internet Service Provider", "Connect.Co", 1300);
        video2.AddComment(new Comment("Mamie", "This changed how internet services can reach rural areas"));
        video2.AddComment(new Comment("Yaya", "Perfect Service for businesses and education."));
        video2.AddComment(new Comment("Gardea", "What is the broadband of the service?"));
        video2.AddComment(new Comment("Mardea", "I am carried away of how this service works."));
        videos.Add(video2);
       //  video 3 creates
        Video video3 = new Video("Mobile Money", "MTN", 850);
        video3.AddComment(new Comment("Yarkpawolo", "Finally, we can receive money from the cities through this service!"));
        video3.AddComment(new Comment("Hawa", "I can sell my fruit and vegetable in the cities on mobile money. Why a wonder!"));
        video3.AddComment(new Comment("Kortee", "This saved me hours of sending money to my children in Monrovia."));
        videos.Add(video3);

        // Add video 4
        Video video4 = new Video("E-Commerce", "Green Food Inc", 1820);
        video4.AddComment(new Comment("Janjay", "Oh, I can sell my food on the internet!"));
        video4.AddComment(new Comment("Yarvoh", " This improved my agricultural project successfully."));
        video4.AddComment(new Comment("Mana", "Well done for helping me to easily sell my product"));
        video4.AddComment(new Comment("Monneh", "Can e-commerce help to reduce the challenges?"));
        videos.Add(video4);

        // All videos and their comments display here.
        Console.WriteLine("YouTube Video for the Tracking of Product");
        Console.WriteLine("======================");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}