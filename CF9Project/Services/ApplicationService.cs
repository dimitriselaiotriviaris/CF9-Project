namespace CF9Project.Services
{
    public class ApplicationService : IApplicationService
    {
        public IUserService UserService { get; }

        public IGameCompanyService GameCompanyService { get; }

        public IGamerService GamerService { get; }

        public ApplicationService(IUserService userService, IGameCompanyService gameCompanyService, 
            IGamerService gamerService)
        {
            UserService = userService;
            GameCompanyService = gameCompanyService;
            GamerService = gamerService;
        }
    }
}
