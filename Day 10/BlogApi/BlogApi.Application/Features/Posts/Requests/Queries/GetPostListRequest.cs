using BlogApi.Application.DTOs.PostDtos;
using MediatR;

namespace BlogApi.Application.Features.Posts.Requests;

public class GetPostListRequest : IRequest<List<PostListDto>>
{
    
}