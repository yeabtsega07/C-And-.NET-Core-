using BlogApi.Application.DTOs.CommentDtos;
using MediatR;

namespace BlogApi.Application.Features.Comments.Requests.Queries;

public class GetCommentListRequest : IRequest<List<CommentListDto>>
{
    
}