using CarRental.Application.Interfaces;
using CarRental.Domain.Entities.Cars;

namespace CarRental.Persistance.EntityFrameworks.Repositories
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(CarRentalContext dbContext) : base(dbContext)
        {
        }

    }
}
