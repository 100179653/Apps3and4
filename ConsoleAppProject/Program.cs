
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;

using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 03 and 04 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Chris Edgley
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            ConsoleHelper.OutputHeading("Main Menu for Apps 3 & 4");
            string[] choices = {
                "APP03: Student Grades System",
                "APP04: Social Network",
            };
            int choice = ConsoleHelper.SelectChoice(choices);

            if (choice == 1)
            {
                StudentGrades studentGrades = new StudentGrades();
                studentGrades.OutputHeading();
            }
            if (choice == 2)
            {
                NetworkApp networkApp = new NetworkApp();
                networkApp.DisplayMenu();
            }
            if (choice == 3)
            {
                
            }
            else
            {
                Console.WriteLine("Please reload the program");
                
            }

        }
    }
}
