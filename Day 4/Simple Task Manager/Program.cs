using System;
using System.Threading.Tasks;
using SimpleTaskManager.Models;
using SimpleTaskManager.Services;
using SimpleTaskManager.Data;

namespace SimpleTaskManager
{
    public class Program
    {
        public static async Task Main()
        {
            // Create a task manager object and load tasks from file
            FileOperations fileOperations = new FileOperations();
            TaskManager taskManager = new TaskManager{
                Tasks = await fileOperations.LoadTasks()

            };

            // Display the menu
;
            while (true)
            {
                Console.WriteLine("Welcome to the Simple Task Manager");
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add a new task");
                Console.WriteLine("2. View all tasks");
                Console.WriteLine("3. View tasks by catagory");
                Console.WriteLine("4. View tasks by completion status");
                Console.WriteLine("5. Mark a task as complete");
                Console.WriteLine("6. Save tasks to file and Exit");


                // Get user input
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add a new task
                        Console.WriteLine("Enter the task title:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the task description:");
                        string description = Console.ReadLine();
                        Console.WriteLine("Enter the task catagory (Personal, Work, Errands, School, Family ):");
                        TaskCatagory catagory = Enum.Parse<TaskCatagory>(Console.ReadLine());
                        
                        // Using object initializer syntax
                        TaskItem taskItem = new TaskItem
                        {
                            Name = name,
                            Description = description,
                            Catagory = catagory,
                            IsCompleted = false
                        };
                        taskManager.AddTask(taskItem);
                        break;

                    case "2":
                        // View all tasks
                        Console.WriteLine("All tasks:");
                        taskManager.ViewTasks();
                        break;

                    case "3":

                        // View tasks by catagory
                        Console.WriteLine("Enter the task catagory (Personal, Work, Errands, School, Family ):");
                        TaskCatagory selectedCatagory = Enum.Parse<TaskCatagory>(Console.ReadLine());
                        Console.WriteLine($"Tasks in {selectedCatagory} catagory:");    
                        taskManager.ViewAllTasksByCatagory(selectedCatagory);
                        break;

                    case "4":

                        // View tasks by completion status
                        Console.WriteLine("To view tasks that are not completed, enter 'false'. To view tasks that are completed, enter 'true'.");
                        bool status = bool.Parse(Console.ReadLine());
                        Console.WriteLine($"Tasks that are {status}:");
                        taskManager.ViewAllTasksByCompletion(status);
                        break;

                    case "5":

                        // Mark a task as complete
                        Console.WriteLine("Enter the name of the task you want to mark as complete: ");
                        string taskName = Console.ReadLine();
                        var selectedTask = taskManager.FindTaskByName(taskName);

                        if (selectedTask == null)
                        {
                            Console.WriteLine($"Task with name {taskName} not found.");
                        }
                        else
                        {
                            selectedTask.MarkAsCompleted();
                            Console.WriteLine($"Task {taskName} marked as complete.");
                        }
                        break;

                    case "6":
                        // Save tasks to file and exit
                        Console.WriteLine("Saving tasks to file...");
                        await fileOperations.SaveTasks(taskManager.Tasks);
                        Console.WriteLine("Tasks saved. Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;                


                }       


            }
        }
    }
}

