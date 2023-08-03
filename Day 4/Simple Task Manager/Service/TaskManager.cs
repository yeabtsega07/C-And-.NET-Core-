using SimpleTaskManager.Models;

namespace SimpleTaskManager.services
{
    public class TaskManager
    {
        public List<Task> Tasks { get; set; }

        public TaskManager()
        {
            Tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            Tasks.Remove(task);
        }

        public void MarkTaskAsComplete(Task task)
        {
            task.MarkAsCompleted();
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
                foreach (var task in Tasks)
                {
                    Console.WriteLine(task);
                }
            }
        }

        public void ViewAllTasksByCatagory(TaskCatagory catagory)
        {   
            // Lambda Function to filter tasks by catagory
            var filteredTasks = Tasks.Where(task => task.Catagory == catagory);

            if (filteredTasks.Count() == 0 )
            {
                Console.WriteLine("No tasks found in {category} catagory.");
            }
            else
            {
                foreach (var task in filteredTasks)
                {
                    if (task.Catagory == catagory)
                    {
                        Console.WriteLine(task);
                    }
                }
            }
        }

        public void ViewAllTasksByCompletion(bool isComplete)
        {   
            // Lambda Function to filter tasks by completion
            var filteredTasks = Tasks.where(task => task.IsComplete == isComplete);

            if (filteredTasks.Count() == 0)
            {   
                // Ternary Operator to check if there are any tasks that are complete or incomplete
                Console.WriteLine( isComplete ? "There are no tasks that are complete.": "There are no tasks that are incomplete." );
            }
            else
            {

                foreach (var task in Tasks)
                {
                    if (task.IsComplete == isComplete)
                    {
                        Console.WriteLine(task);
                    }
                }
            }
        }


    }
}