using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CF9Project.DTO;
using CF9Project.Services;

namespace CF9Project.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IConfiguration _configuration;

        public AuthController(IApplicationService applicationService, IConfiguration configuration)
        {
            _applicationService = applicationService;
            _configuration = configuration;
        }


        /// <summary>/// Registers a new gameCompany account./// </summary>
        [HttpPost("register/gameCompany")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserReadOnlyDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserReadOnlyDTO>> RegisterGameCompany(
            [FromBody] GameCompanySignupDTO gameCompanySignupDTO)
        {
            var createdUser = await _applicationService.GameCompanyService
                .SignUpUserAsync(gameCompanySignupDTO);

            return CreatedAtAction(
                actionName: nameof(UsersController.GetUserById),
                controllerName: "Users",
                routeValues: new { id = createdUser.Id },
                value: createdUser);

        }

    }
}