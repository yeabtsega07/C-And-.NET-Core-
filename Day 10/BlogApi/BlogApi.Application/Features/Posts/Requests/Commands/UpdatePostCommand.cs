using BlogApi.Application.DTOs.PostDtos;
using MediatR;

namespace BlogApi.Application.Features.Posts.Requests.Commands;

public class UpdatePostCommand : IRequest<Unit>
{
    public UpdatePostDto UpdatePostDto { get; set; } = null!;
}