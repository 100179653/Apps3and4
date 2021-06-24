using System;
using System.Collections.Generic;
namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    /// 
    ///</summary>
    ///<user>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.1
    ///  Edited by Chris Edgley
    ///  
    ///</user> 
    public class NewsFeed
    {
        
        private readonly List<Post> posts;

        ///<summary>
        ///  This method constructs an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();
        }

        ///<summary>
        /// This method adds a text post to the news feed.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// This method adds a photo post to the news feed.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        /// <summary>
        /// This method removes a post from the news feed.
        /// </summary>
        public void RemovePost(int id)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost number {id} doesn not exist");
            }
            else
            {
                Console.WriteLine($"\nPost number {id} has been sucessfully removed");
                posts.Remove(post);
            }
        }
        /// <summary>
        /// This method adds a comment to an existing post.
        /// </summary>
        public void AddComment(int id, string comment)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost with ID number {id} doesn not exist");
            }
            else
            {
                Console.WriteLine($"\nComment added to post ID {id}");
                post.AddComment(comment);

            }
        }

        ///<summary>
        /// This method shows the news feed to the user.
        ///</summary>
        public void Display()
        {
            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine("\n--------------------------\n");
            }
        }

        /// <summary>
        /// This method locates a specific post using what number the was created with
        /// </summary>
        public Post FindPost(int id)
        {
            foreach (Post post in posts)
            {
                if (post.PostNumber == id)
                {
                    return post;
                }
            }
            return null;
        }

        /// <summary>
        /// This method displays all posts by a specified date.
        /// </summary>
        /// 
        public void DisplayPostsByDate(string date)
        {
            foreach (Post post in posts)
            {
                if (post.TimeSet.ToLongDateString().Contains(date))
                {
                    post.Display();
                }
            }
        }

        /// <summary>
        /// Display all posts by a specified user.
        /// 
        /// </summary>
        public void DisplayPostsByAuthor(string user)
        {
            foreach (Post post in posts)
            {
                if (post.User == user)
                {
                    post.Display();
                }
            }
        }

        /// <summary>
        /// Add a like to a post. First check to see if the post exists
        /// </summary>
        public void AddLike(int id)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost with ID {id} does not exist");
            }
            else
            {
                Console.WriteLine($"\nLiked post {id}");
            }
            post.LikePost();
        }

        /// <summary>
        /// Unlike a post. First check to see if the post exits.
        /// </summary>
        public void UnlikePost(int id)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost number {id} does not exist");
            }
            else
            {
                Console.WriteLine($"\nUnliked post {id}");
            }
            post.UnlikePost();
        }
    }
}
