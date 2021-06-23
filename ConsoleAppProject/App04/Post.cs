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

        // Get number of posts
        public static int GetPosts()
        {
            return instance;
        }

        /// <summary>
        /// Record one more 'Like' indication from a user.
        /// </summary>
        public void LikePost()
        {
            like++;
            Console.WriteLine("You have successfully liked this post!");
        }

        ///<summary>
        /// Record that a user has withdrawn his/her 'Like' vote.
        /// Ensure this can be done only if the like count is greater
        /// than zero
        ///</summary>
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

        ///<summary>
        /// Add a comment to this post.
        /// </summary>    
        public void AddComment(String commentText)
        {
            comment.Add(commentText);
        }

        ///<summary>
        /// Display the details of this post.
        /// (Currently: Print to the text terminal. This is simulating display 
        /// in a web browser for now.)
        ///</summary>
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

        /// <summary>
        /// Refactored as it made sense to have the display comments
        /// as a separate method
        /// </summary>
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

        ///<summary>
        /// Create a string describing a time point in the past in terms 
        /// relative to current time, such as "30 seconds ago" or "7 minutes ago".
        /// Currently, only seconds and minutes are used for the string.
        /// </summary>
        /// <param name="time">
        ///  The time value to convert (in system milliseconds)
        /// </param> 
        /// <returns>
        /// A relative time string for the given time
        /// </returns>      
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
