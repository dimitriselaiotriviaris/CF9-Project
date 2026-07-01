namespace CF9Project.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IGameCompanyRepository GameCompanyRepository { get; }
        IGamerRepository GamerRepository { get; }
        IGameRepository GameRepository { get; }

        Task<bool> SaveAsync();
    }
}
