using BlogApi.Application.DTOs.Common;

namespace BlogApi.Application.DTOs.PostDtos;

public class PostListDto : BaseDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}