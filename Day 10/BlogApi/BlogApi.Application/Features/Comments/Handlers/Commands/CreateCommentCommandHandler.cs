using AutoMapper;
using BlogApi.Application.Features.Comments.Requests.Commands;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Domain;
using MediatR;

namespace BlogApi.Application.Features.Comments.Handlers.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(request.CreateCommentDto);
        comment =  await _commentRepository.Add(comment);
        return comment.Id;
    }
}