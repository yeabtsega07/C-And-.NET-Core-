using MediatR;

namespace BlogApi.Application.Features.Posts.Requests.Commands;

public class DeletePostCommand : IRequest<Unit>
{
    public int Id { get; set; }
}