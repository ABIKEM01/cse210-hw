using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Video video1 = new Video("Learning C# Basics", "John Doe", 600);
            Video video2 = new Video("Top 10 Coding Tips", "Jane Smith", 420);
            Video video3 = new Video("Object-Oriented Programming Explained", "Mike Johnson", 900);

            
            video1.AddComment(new Comment("Alice", "Great explanation, very helpful!"));
            video1.AddComment(new Comment("Bob", "This made C# so easy to understand."));
            video1.AddComment(new Comment("Charlie", "Thanks for sharing!"));

            
            video2.AddComment(new Comment("David", "Tip #3 really helped me."));
            video2.AddComment(new Comment("Ella", "I liked how short and clear this was."));
            video2.AddComment(new Comment("Frank", "I’m going to apply these tips right away."));

            
            video3.AddComment(new Comment("Grace", "OOP is clearer now, thank you!"));
            video3.AddComment(new Comment("Henry", "Loved the real-world examples."));
            video3.AddComment(new Comment("Isla", "I finally get abstraction!"));

    
            List<Video> videos = new List<Video> { video1, video2, video3 };

            
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

                Console.WriteLine("Comments:");
                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
                }

                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
