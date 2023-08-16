using AutoMapper;
using BlogApi.Application.DTOs.CommentDtos;
using BlogApi.Application.Features.Comments.Requests.Queries;
using BlogApi.Application.Persistence.Contracts;
using MediatR;

namespace BlogApi.Application.Features.Comments.Handlers.Queries;

public class GetCommentDetailRequestHandler : IRequestHandler<GetCommentDetailRequest, CommentDto>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentDetailRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public async Task<CommentDto> Handle(GetCommentDetailRequest request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.Get(request.Id);
        return _mapper.Map<CommentDto>(comment);
    }
}