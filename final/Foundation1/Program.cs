using System;

class Program
{
    static void Main(string[] args)
    {
         var videos = new List<Video>
        {
            new Video("Video 1", "Author 1", 60)
            {
                _comments =
                {
                    new Comment("Commenter 1", "Comment 1 for video 1"),
                    new Comment("Commenter 2", "Comment 2 for video 1"),
                    new Comment("Commenter 3", "Comment 3 for video 1")
                }
            },
            new Video("Video 2", "Author 2", 120)
            {
                _comments =
                {
                    new Comment("Commenter 1", "Comment 1 for video 2"),
                    new Comment("Commenter 2", "Comment 2 for video 2"),
                    new Comment("Commenter 3", "Comment 3 for video 2")
                }
            },
            new Video("Video 3", "Author 3", 180)
            {
                _comments =
                {
                    new Comment("Commenter 1", "Comment 1 for video 3"),
                    new Comment("Commenter 2", "Comment 2 for video 3"),
                    new Comment("Commenter 3", "Comment 3 for video 3")
                }
            },
            new Video("Video 4", "Author 4", 240)
            {
                _comments =
                {
                    new Comment("Commenter 1", "Comment 1 for video 4"),
                    new Comment("Commenter 2", "Comment 2 for video 4"),
                    new Comment("Commenter 3", "Comment 3 for video 4")
                }
            }
        };

        // Display video information and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of comments: {video.NumberOfComments}");

            foreach (var comment in video._comments)
            {
                Console.WriteLine($"{comment._name}: {comment._text}");
            }

            Console.WriteLine();
        }

        Console.ReadLine();

    }
}