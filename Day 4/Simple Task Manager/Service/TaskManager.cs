using SimpleTaskManager.Models;

namespace SimpleTaskManager.Services
{
    public class TaskManager
    {
        public List<TaskItem> Tasks { get; set; }

        public TaskManager()
        {
            Tasks = new List<TaskItem>();
        }

        public void AddTask(TaskItem taskItem)
        {
            Tasks.Add(taskItem);
        }

        public void UpdateTask(TaskItem task, string newName, string newDescription, TaskCategory newCategory)
        {
            task.Name = newName;
            task.Description = newDescription;
            task.Category = newCategory;
        }

        public void MarkTaskAsComplete(TaskItem taskItem)
        {   
            taskItem.MarkAsCompleted();
        }

        // View Tasks
        public void ViewTasks()
        {   
            // Check if there are any tasks
            if (Tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
            }
            else
            {
                foreach (var taskItem in Tasks)
                {
                    Console.WriteLine(taskItem);
                }
            }
        }

        public void ViewAllTasksByCatagory(TaskCategory catagory)
        {   
            // Lambda Function to filter tasks by catagory
            var filteredTasks = Tasks.Where(taskItem => taskItem.Category == catagory);

            if (filteredTasks.Count() == 0 )
            {
                Console.WriteLine($"No tasks found in {catagory} catagory.");
            }
            else
            {
                foreach (var taskItem in filteredTasks)
                {
                    if (taskItem.Category == catagory)
                    {
                        Console.WriteLine(taskItem);
                    }
                }
            }
        }

        public void ViewAllTasksByCompletion(bool isCompleted)
        {   
            // Lambda Function to filter tasks by completion
            var filteredTasks = Tasks.Where(taskItem => taskItem.IsCompleted == isCompleted);

            if (filteredTasks.Count() == 0)
            {   
                // Ternary Operator to check if there are any tasks that are complete or incomplete
                Console.WriteLine( isCompleted ? "There are no tasks that are complete.": "There are no tasks that are incomplete." );
            }
            else
            {

                foreach (var task in Tasks)
                {
                    if (task.IsCompleted == isCompleted)
                    {
                        Console.WriteLine(task);
                    }
                }
            }
        }

        public TaskItem FindTaskByName(string taskName)
        {
            return Tasks.FirstOrDefault(task => task.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase));
        }


    }
}