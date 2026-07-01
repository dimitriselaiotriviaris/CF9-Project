using Microsoft.EntityFrameworkCore;
using CF9Project.Data;
using CF9Project.Models;

namespace CF9Project.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(ProjectMvc9Context context) : base(context)
        {
        }

        public async Task<List<Gamer>> GetGameGamerAsync(int gameId)
        {
            return await _context.Games
               .Where(c => c.Id == gameId)
               .SelectMany(c => c.Gamers)
               .ToListAsync();
        }

        public async Task<GameCompany?> GetGameGameCompanyAsync(int gameId)
        {
           
            var game = await _context.Games
                    .Include(c => c.GameCompany) // eagerly loads related entities in the same query
                    .FirstOrDefaultAsync(c => c.Id == gameId);

            return game?.GameCompany; // not second query, since teacher has loaded
        }
    }
}
