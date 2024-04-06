using RegistrationWebApplication.Core.Domain.DTO_s;
using RegistrationWebApplication.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Core.Domain.RepositoriesContracts
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task<User> GetUserByName(string name);
        public Task<List<User>> GetAllUsersSortedBy(Expression<Func<User, object>> sortingField, int ascDesc);
    }
}
