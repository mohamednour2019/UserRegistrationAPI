using RegistrationWebApplication.Core.Domain.DTO_s;
using RegistrationWebApplication.Core.Domain.Entitites;
using RegistrationWebApplication.Core.Domain.RepositoriesContracts;
using RegistrationWebApplication.Core.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Core.Services
{
    public class GetUserByNameService : IGetUserByNameService
    {
        private readonly IUserRepository _userRepository;
        public GetUserByNameService(IUserRepository userRepository)
        {
            _userRepository= userRepository;    
        }
        public async Task<UserOutputDto> GetUserByName(string name)
        {
            if(name == null) throw new ArgumentNullException("name is null");
            User user=await _userRepository.GetUserByName(name);
            if(user== null) throw new ArgumentNullException("User Nout Found");
            return user.ToUserOutputDto();
        }
    }
}
