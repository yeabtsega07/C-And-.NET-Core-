using BlogApi.Application.DTOs.CommentDtos;
using MediatR;

namespace BlogApi.Application.Features.Comments.Requests.Commands;

public class UpdateCommentCommand : IRequest<Unit>
{
    public UpdateCommentDto UpdateCommentDto { get; set; } = null!;
}