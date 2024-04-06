using Microsoft.EntityFrameworkCore;
using RegistrationWebApplication.Core.Domain.Entitites;
using RegistrationWebApplication.Core.Domain.RepositoriesContracts;
using RegistrationWebApplication.Infrastructure.ApplicationContext;
using System.Linq.Expressions;

namespace RegistrationWebApplication.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
            
        }
        public async Task AddUser(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersSortedBy(Expression<Func<User, object>> sortingField,int ascDesc)
        {
            if (ascDesc == 1)
            {
                return await _appDbContext.Users.OrderBy(sortingField).ToListAsync();
            }
            else
            {
                return await _appDbContext.Users.OrderByDescending(sortingField).ToListAsync();
            }

        }

        public async Task<User> GetUserByName(string name)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x=>x.Name==name);  
        }

    }
}
