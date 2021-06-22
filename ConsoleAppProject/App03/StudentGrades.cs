using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{

    /// <summary>
    /// This is a small app to store, calculate and display 10
    /// student grades.
    /// 
    /// Chris Edgley
    /// 
    /// </summary>
    public class StudentGrades
    {
        // These will stay the stay whilst the application is running

        public const int Ungraded = 0;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestGrade = 100;

        // This will be able to grabbed from the program

        public double MeanMarks { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public string[] MyStudents { get; set; }
        public int[] TheirMarks { get; set; }
        public int[] Gradefile { get; set; }

  
        public StudentGrades()
        {
            MyStudents = new string[]
            {
                "Jo", "Bob",
                "Katt", "Stacey",
                "Clyde", "Andrew",
                "Chris", "Destiny",
                "Shannon", "Phill"
            };

            Gradefile = new int[(int)Grades.A + 1];
            TheirMarks = new int[MyStudents.Length];
        }

        /// <summary>
        /// Using the console helper, this helps establish a
        /// heading for the user to see once they load the 
        /// program
        /// </summary>
        public void OutputHeading()
        {
            ConsoleHelper.OutputHeading("Application for Student Marks");
            SelectChoice();
        }

        /// <summary>
        /// This allows the user to enter marks for all 10 students at once
        /// </summary>
        public void EnterTheMarks()
        {
            Console.WriteLine("Please enter the student's Marks: ");
            
            for (int i = 0; i < MyStudents.Length; i++)
            {
                /// <summary>
                ///   This establishes a query to ask the user for
                ///   a specific student's mark. This query has
                ///   parameters reaching from 0-100 so the user
                ///   can not exceed those parameters
                /// </summary>
                TheirMarks[i] = (int)ConsoleHelper.InputNumber
                    ($"\nPlease enter the mark for student #" + (i + 1) + $" {MyStudents[i]}: ", 0, 100);
            }
            // Now, go back to the main menu
            SelectChoice();
        }
        /// <summary>
        /// This method can compared 
        /// </summary>
        public void OutputTheseMarks()
        {

            ConsoleHelper.OutputTitle("\nStudent Grades");

            /// foreach loop to go through the list of Students and grades
            /// Call the ConvertToGrades method to convert the marks to grade values

            for (int i = 0; i < MyStudents.Length; i++)
            {
                Console.WriteLine($"Student No:{i + 1}\t{MyStudents[i]}\t{TheirMarks[i]}\t{ConvertToGrade(TheirMarks[i])}");
            }
            SelectChoice();
        }

        /// <summary>
        /// Convert a student grade from F to A
        /// </summary>

        public Grades ConvertToGrade(int mark)
        {
            if (mark >= Ungraded && mark < LowestGradeD)
            {
                return Grades.F;
            }
            else if (mark >= LowestGradeD && mark < LowestGradeC)
            {
                return Grades.D;
            }
            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                return Grades.C;
            }
            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                return Grades.B;
            }
            else if (mark >= LowestGradeA && mark <= HighestGrade)
            {
                return Grades.A;
            }
            else
            {
                return Grades.N;
            }
            
        }

        /// <summary>
        /// Calculate and output Minimum, Maximum and MeanMarks TheirMarks for
        /// all 10 MyStudents
        /// </summary>
        public void CalculateStats()
        {
            Minimum = TheirMarks[0];
            Maximum = TheirMarks[0];

            double total = 0;
            foreach (int mark in TheirMarks)
            {
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;
                total += mark;
            }
            MeanMarks = total / TheirMarks.Length;
        }

        /// <summary>
        /// Calculate the grade profile. Loop through the marks and 
        /// assign
        /// </summary>
        public void CalculateGradefile()
        {
            for (int i = 0; i < Gradefile.Length; i++)
            {
                Gradefile[i] = 0;
            }

            foreach (int mark in TheirMarks)
            {
                Grades grade = ConvertToGrade(mark);
                Gradefile[(int)grade]++;
            }
        }


        /// <summary>
        /// Display the student mark statistics: MeanMarks, minumum and maximum TheirMarks
        /// Then when done, return to the main menu
        /// </summary>
        public void OutputTheStats()
        {
            CalculateStats();
            Console.WriteLine("\n### Student Stats ###");
            Console.WriteLine("");
            Console.WriteLine($"This mark was the lowest achieved by a student: {Minimum}");
            Console.WriteLine($"This mark was the lowest achieved by a student: {Maximum}");
            Console.WriteLine($"This mark was the average of all the students: {MeanMarks}");

            SelectChoice();
        }

        // Testing
        public void CalculateMax()
        {
            Minimum = TheirMarks[0];
            Maximum = TheirMarks[100];

            double total = ;
            foreach (int mark in TheirMarks)
            {
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;
                MeanMarks = total / TheirMarks.Length;
            }
        }

        // Testing
        public void CalculateMin()
        {
            Minimum = TheirMarks[0];
            Maximum = TheirMarks[0];

            double total = 0;
            foreach (int mark in TheirMarks)
            {
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;
                MeanMarks = total / TheirMarks.Length;
            }
        }

        /// <summary>
        /// Display the grade profile for all 10 Students
        /// then go back to the main menu. First we need to get the
        /// grade profile then display the results
        /// </summary>
        public void OutputGradefile()
        {
            CalculateGradefile();
            // Start with the default grade of N (NA)
            // TODO: Do not need to display the 'N' grade in the output
            ConsoleHelper.OutputTitle("\n## Student Grades ##\n");
            Grades grade = Grades.N;
            foreach (int count in Gradefile)
            {
                int percent = count * 100 / TheirMarks.Length;

                // Trying \t tabstops to make output easier to read
                Console.WriteLine($"Grade {grade}\t {percent}% \tCount \t{count}");
                grade++;
            }
            
            SelectChoice();
            
        }

        /// <summary>
        /// Prompt the user to enter a choice from the main menu
        /// 1. Enter Marks
        /// 2. Display Marks
        /// 3. Display Stats
        /// 4. Display Grade Profile
        /// 5. Quit the program
        /// </summary>
        public void SelectChoice()
        {
            Console.WriteLine("### MAIN MENU ###");
            Console.WriteLine("\n*** Please select one of the following options ***\n");
            string[] choices = { "Display the student's Marks", "Enter the student's Marks",
                                 "Display Grade File", "Display all students' Stats", "Quit" };
            int choice = ConsoleHelper.SelectChoice(choices);

            if (choice == 1)
            {
                OutputTheseMarks();
            }
            else if (choice == 2)
            {
                EnterTheMarks();
            }
            else if (choice == 3)
            {
                OutputGradefile();
            }
            else if (choice == 4)
            {
                OutputTheStats();
            }
            else if (choice == 5)
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("* Error. Please select a choice (1-5 *");                                                                                   
                SelectChoice(); // Loop back to choose again
            }
        }


    }
}
