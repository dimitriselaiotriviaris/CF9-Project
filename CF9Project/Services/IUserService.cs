using CF9Project.Core;
using CF9Project.Core.Filters;
using CF9Project.DTO;
using CF9Project.Models;

namespace CF9Project.Services
{
    public interface IUserService
    {
        Task<User> VerifyAndGetUserAsync(UserLoginDTO credentials);
        Task<UserReadOnlyDTO> GetUserByUsernameAsync(string username);
        Task<UserReadOnlyDTO> GetUserByIdAsync(int id);
        Task<PaginatedResult<UserReadOnlyDTO>> GetPaginatedUsersFilteredAsync(int pageNumber, 
            int pageSize, UserFiltersDTO userFiltersDTO);
        string CreateUserToken(User user);
    }
}
