using RegistrationWebApplication.Core.Domain.DTO_s;
using RegistrationWebApplication.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Core.ServicesContracts
{
    public interface IGetUserSortedService
    {
        public Task<List<UserOutputDto>> GetAllUsersSortedBy(string key, int ascDesc);
    }
}
