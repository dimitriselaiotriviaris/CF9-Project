using CF9Project.Core;
using CF9Project.Models;
using System.Linq.Expressions;

namespace CF9Project.Repositories
{
    public interface IGameCompanyRepository : IBaseRepository<GameCompany>
    {

        Task<List<Game>> GetGameCompanyGamesAsync(int teacherId);
        Task<User?> GetUserTeacherByUsernameAsync(string username);
        Task<PaginatedResult<User>> GetPaginatedTeachersAsync(int pageNumber, int pageSize,
            List<Expression<Func<User, bool>>> predicates);
    }
}
