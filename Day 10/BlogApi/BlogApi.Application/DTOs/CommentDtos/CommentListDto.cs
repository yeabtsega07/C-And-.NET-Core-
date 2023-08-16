using BlogApi.Application.DTOs.Common;

namespace BlogApi.Application.DTOs.CommentDtos;

public class CommentListDto : BaseDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}