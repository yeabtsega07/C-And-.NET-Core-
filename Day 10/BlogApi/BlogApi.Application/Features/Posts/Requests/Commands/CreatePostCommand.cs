using BlogApi.Application.DTOs.PostDtos;
using MediatR;

namespace BlogApi.Application.Features.Posts.Requests.Commands;

public class CreatePostCommand : IRequest<int>
{
    public CreatePostDto CreatePostDto { get; set; } = null!;
}