using AutoMapper;

using CF9Project.DTO;
using CF9Project.Exceptions;
using CF9Project.Models;
using CF9Project.Repositories;
using CF9Project.Security;


namespace CF9Project.Services
{
    public class GameCompanyService : IGameCompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEncryptionUtil _encryptionUtil;
        private readonly ILogger<GameCompanyService> _logger;

        public GameCompanyService(IUnitOfWork unitOfWork, IMapper mapper, 
            ILogger<GameCompanyService> logger, IEncryptionUtil encryptionUtil)
        {
            _encryptionUtil = encryptionUtil;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserReadOnlyDTO> SignUpUserAsync(GameCompanySignupDTO request)
        {
            var teacher = _mapper.Map<GameCompany>(request);
            var user = _mapper.Map<User>(request);
           
            
            var existingUser = await _unitOfWork.UserRepository.GetUserByUsernameAsync(user.Username);

            if (existingUser != null)
            {
                throw new EntityAlreadyExistsException("User", $"User with username {existingUser.Username} already exists");
            }

            user.GameCompany = gameCompany;
            user.Password = _encryptionUtil.Encrypt(user.Password);
            await _unitOfWork.UserRepository.AddAsync(user);
            
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Teacher {Username} signed up successfully.", user.Username);
            return _mapper.Map<UserReadOnlyDTO>(user);
        }
    }
}
