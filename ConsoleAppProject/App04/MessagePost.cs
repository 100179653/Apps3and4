using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// This class stores information about a post in a social network. 
    /// The main part of the post consists of a (possibly multi-line)
    /// text message. Other data, such as user and time, are also stored.
    /// </summary>
    /// <user>
    /// Michael Kölling and David J. Barnes
    /// Edited by Chris Edgley
    /// version 1.0
    /// </user>
    public class MessagePost : Post
    {
        // an arbitrarily long, multi-line message
        public String Message { get; }

        /// <summary>
        /// Constructor for objects of class MessagePost.
        /// </summary>
        /// <param name="user">
        /// The username of the user of this post.
        /// </param>
        /// <param name="text">
        /// The text of this post.
        /// </param>
        public MessagePost(String user, String text) : base(user)
        {
            Message = text;
        }
        public override void Display()
        {
            Console.WriteLine($"\n    Message: {Message}");
            base.Display();
        }
    }
}
