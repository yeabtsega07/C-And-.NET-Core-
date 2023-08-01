using System;
using System.Collections.Generic;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grade Calculator! 🙌 ");

            // prompt user for name
            Console.Write("Please enter your Full Name: ");
            string fullName = Console.ReadLine();

            // prompt user for number of courses
            Console.Write("Please enter the number of courses you have taken: ");
            int numberOfCourses = int.Parse(Console.ReadLine());

            // prompt user for course names and grades
            Dictionary<string, int> courseGrades = new Dictionary<string, int>();

            for (int i = 0; i < numberOfCourses; i++)
            {
                string courseName;

                // prompt user for course name and validate that it is not a duplicate
                do
                {
                    Console.Write($"Please enter the name of course {i + 1}: ");
                    courseName = Console.ReadLine();

                    if (courseGrades.ContainsKey(courseName))
                    {
                        Console.WriteLine("Course already exists. Please enter a different course name.");
                    }
                    else
                    {
                        break; // Valid course name entered
                    }
                } while (true);

                int courseGrade;

                // prompt user for course grade and validate that it is between 0 and 100
                do
                {
                    Console.Write($"Please enter the grade for {courseName}: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out courseGrade) && courseGrade >= 0 && courseGrade <= 100)
                    {
                        break; // Valid grade entered
                    }
                    else
                    {
                        Console.WriteLine("Invalid grade. Please enter a grade between 0 and 100.");
                    }
                } while (true);

                courseGrades.Add(courseName, courseGrade);
            }

            // calculate average grade
            double totalGrade = 0;
            foreach (var courseGrade in courseGrades)
            {
                totalGrade += courseGrade.Value;
            }

            double averageGrade = totalGrade / numberOfCourses;

            // display results
            Console.WriteLine($"Hello {fullName}! Your grades are: ");

            foreach (var courseGrade in courseGrades)
            {
                Console.WriteLine($"{courseGrade.Key}: {courseGrade.Value}");
            }

            Console.WriteLine($"Hello {fullName}! Your average grade is {averageGrade}.");

        }
    }
}