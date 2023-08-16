using MediatR;

namespace BlogApi.Application.Features.Comments.Requests.Commands;

public class DeleteCommentCommand : IRequest<Unit>
{
    public int Id { get; set; }
}