using CarRental.Application.Interfaces;
using CarRental.Domain.Entities.Accounts;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Persistance.EntityFrameworks.Repositories
{
    public class EfUserRepository : IUserRepository
    {
        private readonly CarRentalContext _dbContext;

        public EfUserRepository(CarRentalContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUser(User user)
        {
            await _dbContext.Set<User>().AddAsync(user);
        }

        public async Task<User?> GetUserWithDetail(string email)
        {
            return await _dbContext.Set<User>()
                .Include(x=>x.UserDetail)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
