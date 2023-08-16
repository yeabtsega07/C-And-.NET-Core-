using AutoMapper;
using BlogApi.Application.DTOs.PostDtos;
using BlogApi.Application.Features.Posts.Requests;
using BlogApi.Application.Persistence.Contracts;
using MediatR;

namespace BlogApi.Application.Features.Posts.Handlers.Queries;

public class GetPostDetailRequestHandler : IRequestHandler<GetPostDetailRequest, PostDto>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    
    public GetPostDetailRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    
    public async Task<PostDto> Handle(GetPostDetailRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.Get(request.Id);
        return _mapper.Map<PostDto>(post);
    }
}