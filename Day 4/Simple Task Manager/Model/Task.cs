
namespace SimpleTaskManager.Models
{
    public enum TaskCatagory
    {
        Personal,
        Work,
        Errands,
        School,
        Family,
        Friends,

        // Add more as needed

    }

    public class Task 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskCatagory Catagory { get; set; }
        public bool IsComplete { get; set; }

        // public Task(string title, string description, TaskCatagory catagory)
        // {
        //     Title = title;
        //     Description = description;
        //     Catagory = catagory;
        //     IsComplete = false;
        // }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public override string ToString()
        {
            return $"Title: {Title}\nDescription: {Description}\nCatagory: {Catagory}\nIsComplete: {IsComplete}";
        }
    }
}