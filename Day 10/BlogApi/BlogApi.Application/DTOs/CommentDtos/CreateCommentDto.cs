

namespace BlogApi.Application.DTOs.CommentDtos;

public class CreateCommentDto 
{
    public string Content { get; set; } = null!;
    public int PostId { get; set; }
}