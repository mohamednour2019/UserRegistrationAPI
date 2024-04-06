using RegistrationWebApplication.Core.Domain.DTO_s;
using RegistrationWebApplication.Core.Domain.Entitites;
using RegistrationWebApplication.Core.Domain.RepositoriesContracts;
using RegistrationWebApplication.Core.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Core.Services
{
    public class GetUserSortedService : IGetUserSortedService
    {
        private readonly IUserRepository _userRepository;
        public GetUserSortedService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserOutputDto>> GetAllUsersSortedBy(string key,int ascDesc)
        {
           if(key == null) { throw new Exception("sorting provide sorting field please!"); }
            Expression<Func<User, object>> usersFilter = key switch
            {
                "name" => (User u) => u.Name,
                "age"  => (User u) => u.Name,
                "date" => (User u) => u.DateTime
            };

           List<User> users=await _userRepository.GetAllUsersSortedBy(usersFilter, ascDesc);
           if(users == null) { throw new Exception("there are no users yet!"); }

           return users.Select(x=>x.ToUserOutputDto()).ToList();
        }
    }
}
