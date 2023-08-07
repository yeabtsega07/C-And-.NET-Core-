// Program.cs
using System;

class Program
{
    static void Main()
    {   
        // create a new StudentList object which is a generic class
        var studentList = new StudentList<Student>();
        // specify the path to the JSON file
        string filePath = "students.json";

        Console.WriteLine("Student Management System");
        Console.WriteLine("*************************");

        // display the menu until the user exits
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nWelcome please select an option:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student by Name");
            Console.WriteLine("3. Search Student by ID");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Save Data to JSON");
            Console.WriteLine("6. Load Data from JSON");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                // create a new Student object and add it to the list
                case "1":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Roll Number: ");
                    int rollNumber = int.Parse(Console.ReadLine());
                    Console.Write("Enter Grade: ");
                    string grade = Console.ReadLine();

                    var newStudent = new Student(name, age, rollNumber, grade);
                    studentList.AddStudent(newStudent);
                    Console.WriteLine("Student added successfully.");
                    break;

                // search for a student by name
                case "2":
                    Console.Write("Enter the name to search: ");
                    string searchName = Console.ReadLine();
                    var resultByName = studentList.SearchStudent(s => s.Name == searchName);
                    if (resultByName != null)
                    {
                        Console.WriteLine("Student Found:");
                        Console.WriteLine($"Name: {resultByName.Name}, Age: {resultByName.Age}, " +
                                        $"Roll Number: {resultByName.RollNumber}, Grade: {resultByName.Grade}");
                    }
                    else
                    {
                        Console.WriteLine("No student found with the given name.");
                    }

                    break;

                // search for a student by ID
                case "3":
                    Console.Write("Enter the ID to search: ");
                    int searchID = int.Parse(Console.ReadLine());
                    var resultByID = studentList.SearchStudent(s => s.RollNumber == searchID);
                    if (resultByID != null)
                    {
                        Console.WriteLine("Student Found:");
                        Console.WriteLine($"Name: {resultByID.Name}, Age: {resultByID.Age}, " +
                                        $"Roll Number: {resultByID.RollNumber}, Grade: {resultByID.Grade}");
                    }
                    else
                    {
                        Console.WriteLine("No student found with the given ID.");
                    }
                    break;


                // display all students
                case "4":
                    Console.WriteLine("All Students:");
                    studentList.DisplayAllStudents();
                    break;


                // save data to JSON
                case "5":
                    studentList.SerializeToJson(filePath);
                    Console.WriteLine("Data saved to JSON successfully.");
                    break;
                
                // load data from JSON
                case "6":
                    studentList.DeserializeFromJson(filePath);
                    Console.WriteLine("Data loaded from JSON successfully.");
                    break;
                
                // exit the program
                case "7":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Student Management System!");
    }
}
