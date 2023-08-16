using AutoMapper;
using BlogApi.Application.DTOs.PostDtos.Validators;
using BlogApi.Application.Features.Posts.Requests.Commands;
using BlogApi.Application.Persistence.Contracts;
using BlogApi.Domain;
using MediatR;

namespace BlogApi.Application.Features.Posts.Handlers.Commands;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreatePostDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CreatePostDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new Exception();
        }
        
        var post = _mapper.Map<Post>(request.CreatePostDto);
        post = await _postRepository.Add(post);
        return post.Id;
    }
}