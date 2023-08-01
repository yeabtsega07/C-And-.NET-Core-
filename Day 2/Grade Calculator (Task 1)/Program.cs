using System;
using System.Collections.Generic;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grade Calculator! 🙌 ");

            Console.Write("Please enter your Full Name: ");
            string fullName = Console.ReadLine();

            Console.Write("Please enter the number of courses you have taken: ");
            int numberOfCourses = int.Parse(Console.ReadLine());

            Dictionary<string, int> courseGrades = new Dictionary<string, int>();

            for (int i = 0; i < numberOfCourses; i++)
            {
                string courseName;

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

            double averageGrade = GetAverageGrade(courseGrades);

            Console.WriteLine($"Hello {fullName}! Your grades are: ");

            foreach (var courseGrade in courseGrades)
            {
                Console.WriteLine($"{courseGrade.Key}: {courseGrade.Value}");
            }

            Console.WriteLine($"Hello {fullName}! Your average grade is {averageGrade}.");

        }

        static float GetAverageGrade(Dictionary<string, int> courseGrades)
        {
            float totalGrade = 0;
            foreach (var courseGrade in courseGrades)
            {
                totalGrade += courseGrade.Value;
            }

            float averageGrade = totalGrade / courseGrades.Count;

            return averageGrade;
        }
    }
}