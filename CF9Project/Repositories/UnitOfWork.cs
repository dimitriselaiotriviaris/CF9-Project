using CF9Project.Data;

namespace CF9Project.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectMvc9Context _context;
        public IUserRepository UserRepository { get; }
        public IGameCompanyRepository GameCompanyRepository { get; }
        public IGamerRepository GamerRepository { get; }
        public IGameRepository GameRepository { get; }

        public UnitOfWork(ProjectMvc9Context context)
        {
            _context = context;
            UserRepository = new UserRepository(context);
            GameCompanyRepository = new GameCompanyRepository(context);
            GamerRepository = new GamerRepository(context);
            GameRepository = new GameRepository(context);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;   // commit & rollback
        }
    }
}
