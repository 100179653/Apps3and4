using System;
using System.Collections.Generic;
namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    /// 
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.1
    ///  Edited by Chris Edgley
    ///  
    ///</author> 
    public class NewsFeed
    {
        
        private readonly List<Post> posts;

        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();

            // Testing by placing a message post and a photo post
            //MessagePost post = new MessagePost(author, "Hello world! You are awesome");
            //AddMessagePost(post);

            //PhotoPost photoPost = new PhotoPost(author, "pic1.jpg", "Me and my dogs!");
            //AddPhotoPost(photoPost);
        }

        ///<summary>
        /// Add a text post to the news feed.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        /// <summary>
        /// Remove a post from the news feed.
        /// Check to see if the post exists; if it does, execute the Remove
        /// method. If it does not exist, show an error message
        /// </summary>
        public void RemovePost(int id)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost with ID number {id} doesn not exist");
            }
            else
            {
                Console.WriteLine($"\nPost ID {id} has been sucessfully removed");
                posts.Remove(post);
            }
        }
        /// <summary>
        /// Add a comment to an existing post. Check to see if the post exists
        /// before adding
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
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
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (TODO: replace this later with display in web browser.)
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
        /// Locate a specific post ID within the posts by trying to
        /// match the ID passed to an ID already in the system
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
        /// Display all posts by a specified date.
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
        /// Display all posts by a specified author.
        /// NOTE: This could really do wirh proper error handling
        /// </summary>
        public void DisplayPostsByAuthor(string author)
        {
            foreach (Post post in posts)
            {
                if (post.User == author)
                {
                    post.Display();
                }
            }
        }

        /// <summary>
        /// Add a like to a post. First check to see if the post exists
        /// </summary>
        /// <param name="id"></param>
        public void AddLike(int id)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost with ID number {id} doesn not exist");
            }
            else
            {
                Console.WriteLine($"\nLike added to post ID {id}");
            }
            post.LikePost();
        }

        /// <summary>
        /// Unlike a post. First check to see if the post exits.
        /// </summary>
        /// <param name="id"></param>
        public void UnlikePost(int id)
        {
            Post post = FindPost(id);
            if (post == null)
            {
                Console.WriteLine($"\nPost with ID number {id} doesn not exist");
            }
            else
            {
                Console.WriteLine($"\nUnliked post ID {id}");
            }
            post.UnlikePost();
        }
    }
}
