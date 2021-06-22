using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
    public class Post
    {
        private int likes;

        private readonly List<String> comments;

        public int PostID { get; }

        public static int instances = 0;

        public String Username { get; }

        public DateTime Timestamp { get; }

        public Post(string author)
        {
            instances++;
            this.Username = author;
            Timestamp = DateTime.Now;
            likes = 0;
            comments = new List<String>();
            PostID = instances;
        }

        // Get number of posts
        public static int GetNumberOfPosts()
        {
            return instances;
        }

        /// <summary>
        /// Record one more 'Like' indication from a user.
        /// </summary>
        public void Like()
        {
            likes++;
        }

        ///<summary>
        /// Record that a user has withdrawn his/her 'Like' vote.
        /// Ensure this can be done only if the like count is greater
        /// than zero
        ///</summary>
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }

        ///<summary>
        /// Add a comment to this post.
        /// </summary>    
        public void AddComment(String commentText)
        {
            comments.Add(commentText);
        }

        ///<summary>
        /// Display the details of this post.
        /// (Currently: Print to the text terminal. This is simulating display 
        /// in a web browser for now.)
        ///</summary>
        public virtual void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"    Post ID#:     {PostID}");
            Console.WriteLine($"    Author:       {Username}");
            Console.WriteLine($"    Time Elpased: {FormatElapsedTime(Timestamp)}");
            Console.WriteLine();

            if (likes > 0)
            {
                Console.WriteLine($"    Likes:  {likes}  people like this.");
            }
            else
            {
                Console.WriteLine();
            }

            if (comments.Count == 0)
            {
                Console.WriteLine("    No comments.");
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
            Console.WriteLine($"    {comments.Count}  comment(s)");
            foreach (string comment in comments)
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
