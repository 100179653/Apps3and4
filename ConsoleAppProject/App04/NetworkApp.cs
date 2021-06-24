using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// Main app menu to call the various other methods
    /// within the scope of this app. Loop this menu while
    /// the boolean condition for quitting is false.
    /// 
    /// Chris Edgley
    /// 
    /// </summary>
    public class NetworkApp
    {
        private readonly NewsFeed news = new NewsFeed();
        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("---Network App---");

            DisplayCurrentDateAndTime();

            string[] choices = new string[]
            {
                "Make a message Post",
                "Make an Image Post",
                "Remove a post",
                "Add a comment to a Post",
                "Like/Unlike a post",
                "Show all users' Posts",
                "Filter posts by Date/Time",
                "Display Posts by User",
                "Close the Social Network App",
            };

            bool wantToQuit = false;
            do
            {
                ConsoleHelper.OutputTitle("--Main Menu--");
                int choice = ConsoleHelper.SelectChoice(choices);
                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: RemovePost(); break;
                    case 4: AddComment(); break;
                    case 5: LikeOrUnlikePost(); break;
                    case 6: DisplayAll(); break;
                    case 7: DisplayByDate(); break;
                    case 8: DisplayByAuthor(); break;
                    case 9: wantToQuit = true; break;
                }
            } while (!wantToQuit);
        }

        /// <summary>
        /// Given that we're going to be asking for an user name throughout
        /// this app, it makes sense to implement a specific method for
        /// getting the 'user' that we can re-use.
        /// </summary>
        public string InputName()
        {
            Console.Write(" Please enter your name: ");
            string user = Console.ReadLine();
            return user; // pass the string back out
        }

        /// <summary>
        /// Add a post message; ask the user for their name then ask
        /// for the message. Pass the message to the AddMessagePost
        /// then display the message
        /// </summary>
        private void PostMessage()
        {
            ConsoleHelper.OutputTitle("Posting a Message");
            string user = InputName();

            Console.Write(" Please enter your message: ");
            string message = Console.ReadLine();
            
            MessagePost post = new MessagePost(user, message);
            news.AddMessagePost(post);
            PostSuccessMessage();
            post.Display();
        }

        /// <summary>
        /// Add a photo message; ask the user for their name then
        /// ask for an image filename followed by an image caption.
        /// Pass the user, filename and caption to AddPhotoPost 
        /// then display the message.
        /// </summary>
        private void PostImage()
        {
            ConsoleHelper.OutputTitle("Posting an Image");
            string user = InputName();

            Console.Write("Please enter the image file location: ");
            string filename = Console.ReadLine();

            Console.Write("Please enter what you would like as the caption: ");
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(user, filename, caption);
            news.AddPhotoPost(post);
            PostSuccessMessage();
            post.Display();
        }

        /// <summary>
        /// Display all the posts made on the system
        /// </summary>
        private void DisplayAll()
        {
            ConsoleHelper.OutputTitle("Displaying all Post");
            news.Display();
        }

        /// <summary>
        /// Display the posts by date.
        /// NOTE: This is a messy workaround as the user must supply the month manually.
        /// </summary>
        private void DisplayByDate()
        {
            ConsoleHelper.OutputTitle("Displaying all posts by Date and Time");
            Console.Write(" Please enter the month of the area of posts you wish to see: ");
            string date = Console.ReadLine();
            ConsoleHelper.OutputTitle($" Displaying posts by month: {date}");
            news.DisplayPostsByDate(date);
        }
        /// <summary>
        /// Display all posts by a specific user
        /// </summary>
        private void DisplayByAuthor()
        {
            ConsoleHelper.OutputTitle("Displaying all posts by the User");
            Console.Write(" Please enter the user's name: ");
            string user = Console.ReadLine();
            ConsoleHelper.OutputTitle($" Displaying posts by user: {user}");
            news.DisplayPostsByAuthor(user);
        }

        /// <summary>
        /// Delete a post from the system. Get a number from the 
        /// user by using the ConsoleHelper class 
        /// </summary>
        private void RemovePost()
        {
            ConsoleHelper.OutputTitle("Removing a Post");
            int id = (int)ConsoleHelper.InputNumber("Please enter the number of which post to delete: ", 1, Post.GetPosts());
            news.RemovePost(id);
        }

        /// <summary>
        /// Add a comment to a post. Ask user for ID number of comment
        /// </summary>
        private void AddComment()
        {
            
            ConsoleHelper.OutputTitle("Adding a comment to a Post");
            int id = (int)ConsoleHelper.InputNumber("Please enter the number of which post to add a comment to: ", 1, Post.GetPosts());

            Console.Write("    # Please enter your comment: ");
            string comment = Console.ReadLine();
            news.AddComment(id, comment);
        }

        /// <summary>
        /// Like or unlike a post. Ask use for ID number of post
        /// </summary>
        private void LikeOrUnlikePost()
        {
            ConsoleHelper.OutputTitle("Liking/Unliking of Posts");

            Console.Write("    # Would you rather (1) Unlike or (2) Like a post?: ");
            string likeOrUnlike = Console.ReadLine();

            if(likeOrUnlike == "2")
            {
                int id = (int)ConsoleHelper.InputNumber("Please enter the number of which post to add a like to: ", 1, Post.GetPosts());
                news.AddLike(id);
            }
            else if (likeOrUnlike == "1")
            {
                int id = (int)ConsoleHelper.InputNumber("Please enter the number of which post to remove a like from: ", 1, Post.GetPosts());
                news.UnlikePost(id);
            } 
        }

        /// <summary>
        /// Short method to display the current date and time to the user
        /// </summary>
        private void DisplayCurrentDateAndTime()
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("\t---------------------------\n");
            Console.WriteLine("\tThe Current Date is: " + dateTime.ToLongDateString());
            Console.WriteLine("\tThe Current Time is: " + dateTime.ToLongTimeString());
            Console.WriteLine("\t---------------------------\n");
        }

        /// <summary>
        /// Display a success message to the user when they have made
        /// a post
        /// </summary>
        private void PostSuccessMessage()
        {
            Console.WriteLine("Your message was posted sucessfully!");
        }
    } 
}
