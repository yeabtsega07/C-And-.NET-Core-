using BlogApi.Domain.Common;

namespace BlogApi.Domain;

public class Comment : BaseDomainEntity
{
    public string Content { get; set; } = "";
    public int PostId { get; set; }
    public virtual Post? Post { get; set; } 
}