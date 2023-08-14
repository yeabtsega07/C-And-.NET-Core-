using BlogApi.Domain;

namespace BlogApi.Application.Persistence.Contracts;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<IReadOnlyList<Comment>> GetForPost();
}