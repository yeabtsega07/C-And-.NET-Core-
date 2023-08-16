using AutoMapper;
using BlogApi.Application.DTOs.PostDtos;
using BlogApi.Application.Features.Posts.Requests;
using BlogApi.Application.Persistence.Contracts;
using MediatR;

namespace BlogApi.Application.Features.Posts.Handlers.Queries;

public class GetPostListRequestHandler : IRequestHandler<GetPostListRequest, List<PostListDto>>
{   
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    
    public GetPostListRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    
    public async Task<List<PostListDto>> Handle(GetPostListRequest request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAll();
            return _mapper.Map<List<PostListDto>>(posts);
        }   
}