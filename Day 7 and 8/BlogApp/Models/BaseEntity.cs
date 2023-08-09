
namespace BlogApp.Models;

    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
