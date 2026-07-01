namespace CF9Project.Services
{
    public interface IApplicationService
    {
        IUserService UserService { get; }
        IGameCompanyService GameCompanyService { get; }
        IGamerService GamerService { get; }

        // Other services can be added here 
    }
}
