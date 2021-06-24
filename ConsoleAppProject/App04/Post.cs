using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    public class Post
    {
        public static int instance = 0;

        public String User { get; }

        public DateTime TimeSet { get; }

        private int like;

        private readonly List<String> comment;

        public int PostNumber { get; }

        public Post(string poster)
        {
            instance++;
            User = poster;
            TimeSet = DateTime.Now;
            like = 0;
            comment = new List<String>();
            PostNumber = instance;
        }

        // This method gets number of posts
        public static int GetPosts()
        {
            return instance;
        }

        // This methods allows a user to like a post
        public void LikePost()
        {
            like++;
            Console.WriteLine("You have successfully liked this post!");
        }

        // This method allows a user to unlike a post
        // Likes can not be removed if there are 0 likes
        public void UnlikePost()
        {
            if (like > 0)
            {
                like = like - 1;
                Console.WriteLine("You have successfully unliked this post!");
            }
            else
            {
                Console.WriteLine("You can not unlike a post with no likes!");
            }
        }
        
        // This method allows a user to add a comment to a post
        public void AddComment(String commentText)
        {
            comment.Add(commentText);
        }

        // This method allows a user remove a comment to a post   
        public void RemoveComment(String commentText)
        {
            comment.Remove(commentText);
        }

        // This method prints the post to the console
        public virtual void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"    Post Number:     {PostNumber}");
            Console.WriteLine($"    User who made the post:       {User}");
            Console.WriteLine($"    Time since the post was made: {FormatElapsedTime(TimeSet)}");
            Console.WriteLine();

            if (like > 0)
            {
                Console.WriteLine($"    Likes:  {like}  have liked this post.");
            }
            else
            {
                Console.WriteLine();
            }

            if (comment.Count == 0)
            {
                Console.WriteLine("    There have been no comments made.");
            }
            else
            {
                DisplayComments();
            }
        }

        // This method allows a user to see the comments made on a post
        public void DisplayComments()
        {
            int commentNumber = 0;
            Console.WriteLine($"    There are    {comment.Count}  comment(s)");
            foreach (string comment in comment)
            {
                commentNumber++;
                Console.WriteLine($"    Comment: {commentNumber}    {comment}\n");
            }
        }
        
        // This method enables the posts to have a specific time posted
        // Then can be used to show how long age the post was made
        private String FormatElapsedTime(DateTime time)
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }
    }
}
