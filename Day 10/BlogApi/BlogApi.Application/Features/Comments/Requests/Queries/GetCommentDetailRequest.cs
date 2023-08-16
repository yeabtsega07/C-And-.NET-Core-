using BlogApi.Application.DTOs.CommentDtos;
using MediatR;

namespace BlogApi.Application.Features.Comments.Requests.Queries;

public class GetCommentDetailRequest : IRequest<CommentDto>
{
    public int Id { get; set; }
}