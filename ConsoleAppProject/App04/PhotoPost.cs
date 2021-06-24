using System;
using System.Collections.Generic;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// This class stores information about a post in a social network. 
    /// The main part of the post consists of a photo and a caption. 
    /// Other data, such as user and time, are also stored.
    ///</summary>
    /// <user>
    /// Michael Kölling and David J. Barnes
    /// @version 0.1
    /// Edited by Chris Edgley
    /// </user>
    public class PhotoPost : Post
    {

        // the name of the image file
        public String Name { get; set; }
        
        // a one line image caption
        public String Details { get; set; }   
        
        ///<summary>
        /// This constructs the class PhotoPost
        /// It allows the creation photos being
        /// able to be produce posts with a photo
        ///</summary>
        public PhotoPost(String User, string Name, String Details): base(User)
        {
            this.Name = Name;
            this.Details = Details;
        }
        public override void Display()
        {
            Console.WriteLine($"    name of the file: [{Name}]");
            Console.WriteLine($"    Caption: {Details}");
            base.Display();
        }
    }
}
