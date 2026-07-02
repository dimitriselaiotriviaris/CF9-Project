using Microsoft.EntityFrameworkCore;
using CF9Project.Core;
using CF9Project.Data;
using CF9Project.Models;
using System.Linq.Expressions;

namespace CF9Project.Repositories
{
    public class GameCompanyRepository : BaseRepository<GameCompany>, IGameCompanyRepository
    {
        public GameCompanyRepository(ProjectMvc9Context context) : base(context)
        {
        }

        public async Task<User?> GetUserGameCompanyByUsernameAsync(string username)
        {
            var userTeacher = await _context.Users
                .Include(u => u.GameCompany) // Eager loading like Join in SQL
                .Where(u => u.Username == username && u.GameCompany != null)
                .SingleOrDefaultAsync();    // fetches 0 or 1 results, throws Exception

            return userTeacher;
        }
        public async Task<PaginatedResult<User>> GetPaginatedTeachersAsync(int pageNumber, int pageSize, List<Expression<Func<User, bool>>> predicates)
        {
            int totalRecords;
            IQueryable<User> query = _context.Users
                .Include(u => u.GameCompany)
                .Where(u => u.GameCompany != null); // Φιλτράρουμε μόνο τους χρήστες που είναι δάσκαλοι

            if (predicates != null && predicates.Count > 0)
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate); // υπονοείται το AND
                }
            }

            totalRecords = await query.CountAsync();
            int skip = (pageNumber - 1) * pageSize;

            var data = await query
                .OrderBy(u => u.Id) // Πάντα OrderBy για να διασφαλίσουμε την σταθερή σειρά των αποτελεσμάτων
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<User>()
            {
                Data = data,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<Game>> GetGameCompanyGamesAsync(int gameCompanyId)
        {
            List<Game> games;

            games = await _context.Games
                .Where(c => c.GameCompanyId == gameCompanyId)
                .ToListAsync();

            return games;
        }

        
    }
}
