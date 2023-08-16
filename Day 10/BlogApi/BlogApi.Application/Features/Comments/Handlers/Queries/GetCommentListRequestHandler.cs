using AutoMapper;
using BlogApi.Application.DTOs.CommentDtos;
using BlogApi.Application.Features.Comments.Requests.Queries;
using BlogApi.Application.Persistence.Contracts;
using MediatR;

namespace BlogApi.Application.Features.Comments.Handlers.Queries;

public class GetCommentListRequestHandler : IRequestHandler<GetCommentListRequest, List<CommentListDto>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentListRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public async Task<List<CommentListDto>> Handle(GetCommentListRequest request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetAll();
        return _mapper.Map<List<CommentListDto>>(comments);
    }
}