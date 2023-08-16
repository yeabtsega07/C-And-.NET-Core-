using BlogApi.Application.DTOs.CommentDtos;
using MediatR;

namespace BlogApi.Application.Features.Comments.Requests.Commands;

public class CreateCommentCommand : IRequest<int>
{
    public CreateCommentDto CreateCommentDto { get; set; } = null!;
}