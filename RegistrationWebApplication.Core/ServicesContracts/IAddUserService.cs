using RegistrationWebApplication.Core.Domain.DTO_s;

namespace RegistrationWebApplication.Core.ServicesContracts
{
    public interface IAddUserService
    {
        public Task<UserOutputDto> AddUser(UserInputDto user);
    }
}
