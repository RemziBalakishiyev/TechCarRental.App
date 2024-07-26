using CarRental.Application.Interfaces;
using CarRental.Domain.Entities.Cars;

namespace CarRental.Persistance.EntityFrameworks.Repositories;

public class EfCarRepository : EfGenericRepository<Car>, ICarRepository
{
    public EfCarRepository(CarRentalContext dbContext) : base(dbContext)
    {
    }
}
