using CF9Project.Models;
using CF9Project.Core;
using CF9Project.Data;
using System.Linq.Expressions;

namespace CF9Project.Repositories
{
    public interface IGamerRepository : IBaseRepository<Gamer>
    {
        Task<List<Game>> GetGamerGamesAsync(int gamerId);
        Task<PaginatedResult<User>> GetPaginatedUsersGamersAsync(int pageNumber, int pageSize);
        Task<PaginatedResult<Gamer>> GetPaginatedUsersGamersFilteredAsync(int pageNumber, int pageSize,
            List<Expression<Func<Gamer, bool>>> predicates);
    }
}
