using AutoMapper;
using BlogApi.Application.Features.Posts.Requests.Commands;
using BlogApi.Application.Persistence.Contracts;
using MediatR;

namespace BlogApi.Application.Features.Posts.Handlers.Commands;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
{   
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.Get(request.UpdatePostDto.Id);
        _mapper.Map(request.UpdatePostDto, post);
        await _postRepository.Update(post);
        return Unit.Value;
    }
}