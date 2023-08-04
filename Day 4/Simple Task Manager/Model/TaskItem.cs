
namespace SimpleTaskManager.Models
{
    public enum TaskCategory
    {
        Personal,
        Work,
        Errands,
        School,
        Family,
        // Add more as needed

    }

    public class TaskItem 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskCategory Category { get; set; }
        public bool IsCompleted { get; set; }



        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nDescription: {Description}\nCatagory: {Category}\nIsComplete: {IsCompleted}";
        }
    }
}