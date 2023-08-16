using BlogApi.Application.DTOs.PostDtos;
using MediatR;

namespace BlogApi.Application.Features.Posts.Requests;

public class GetPostDetailRequest : IRequest<PostDto>
{
    public int Id { get; set; }
}