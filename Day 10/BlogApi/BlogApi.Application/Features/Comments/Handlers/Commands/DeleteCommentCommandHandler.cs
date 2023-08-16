using AutoMapper;
using BlogApi.Application.Features.Posts.Requests.Commands;
using BlogApi.Application.Persistence.Contracts;
using MediatR;

namespace BlogApi.Application.Features.Comments.Handlers.Commands;

public class DeleteCommentCommandHandler : IRequestHandler<DeletePostCommand, Unit>
{
    
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.Get(request.Id);
        await _commentRepository.Delete(comment);
        return Unit.Value;
    }
}