using BlogApi.Application.DTOs.Common;

namespace BlogApi.Application.DTOs.CommentDtos;

public class CommentDto : BaseDto
{
    public string Text { get; set; } = null!;
    public int PostId { get; set; }
    public DateTime CreatedAt {get; set;}
}