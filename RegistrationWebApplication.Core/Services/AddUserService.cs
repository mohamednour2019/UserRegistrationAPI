using RegistrationWebApplication.Core.Domain.DTO_s;
using RegistrationWebApplication.Core.Domain.Entitites;
using RegistrationWebApplication.Core.Domain.RepositoriesContracts;
using RegistrationWebApplication.Core.Helpers;
using RegistrationWebApplication.Core.ServicesContracts;


namespace RegistrationWebApplication.Core.Services
{
    public class AddUserService : IAddUserService
    {
        private readonly IGetDateService _getDateService;
        private readonly IUserRepository _userRepository;
        public AddUserService(IGetDateService getDateService, IUserRepository userRepository)
        {
            _getDateService = getDateService;
            _userRepository = userRepository;
        }
        public async Task<UserOutputDto> AddUser(UserInputDto user)
        {
            ValidationHelper.ModelValidation(user);
            DateTime date = await _getDateService.GetDate(user.Contenital, user.Country);
            Guid newId= Guid.NewGuid();
            User newUser = user.ToUser();
            newUser.Id = newId;
            newUser.DateTime = date;
            await _userRepository.AddUser(newUser);
            return newUser.ToUserOutputDto();
        }
    }
}
