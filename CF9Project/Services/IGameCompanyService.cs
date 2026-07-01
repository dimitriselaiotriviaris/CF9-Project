using CF9Project.DTO;

namespace CF9Project.Services
{
    public interface IGameCompanyService
    {
        Task<UserReadOnlyDTO> SignUpUserAsync(GameCompanySignupDTO request);
    }
}
