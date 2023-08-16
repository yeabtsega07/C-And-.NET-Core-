using AutoMapper;
using BlogApi.Application.Features.Posts.Requests.Commands;
using BlogApi.Application.Persistence.Contracts;
using MediatR;

namespace BlogApi.Application.Features.Posts.Handlers.Commands;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.Get(request.Id);
        await _postRepository.Delete(post);
        return Unit.Value;
    }
}