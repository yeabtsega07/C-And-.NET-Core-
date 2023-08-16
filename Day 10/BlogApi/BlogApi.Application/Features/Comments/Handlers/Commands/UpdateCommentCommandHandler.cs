using AutoMapper;
using BlogApi.Application.Features.Comments.Requests.Commands;
using BlogApi.Application.Persistence.Contracts;
using MediatR;

namespace BlogApi.Application.Features.Comments.Handlers.Commands;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
{   
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.Get(request.UpdateCommentDto.Id);
        _mapper.Map(request.UpdateCommentDto, comment);
        await _commentRepository.Update(comment);
        return Unit.Value;
    }
}