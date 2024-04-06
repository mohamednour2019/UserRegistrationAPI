using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Core.ServicesContracts
{
    public interface IGetDateService
    {
        Task<DateTime> GetDate(string Contenintal,string Country); 
    }
}
