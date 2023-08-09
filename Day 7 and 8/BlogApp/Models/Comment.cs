namespace BlogApp.Models
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; } = "";
        public int PostId { get; set; }
        public virtual Post? Post { get; set; }

    }
}