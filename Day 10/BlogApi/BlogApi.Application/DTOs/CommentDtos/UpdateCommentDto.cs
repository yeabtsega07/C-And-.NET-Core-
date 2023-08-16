using BlogApi.Application.DTOs.Common;

namespace BlogApi.Application.DTOs.CommentDtos;

public class UpdateCommentDto : BaseDto
{
    public string Content { get; set; } = null!;
    public int PostId { get; set; }
}