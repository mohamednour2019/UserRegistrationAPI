using RegistrationWebApplication.Core.Domain.DTO_s;
using RegistrationWebApplication.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Core.ServicesContracts
{
    public interface IGetUserByNameService
    {
        public Task<UserOutputDto> GetUserByName(string name);
    }
}
