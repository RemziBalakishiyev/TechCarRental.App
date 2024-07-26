using CarRental.Application.Interfaces;
using CarRental.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace CarRental.Persistance.EntityFrameworks.Repositories;

public class EfGenericRepository<T> : IRepository<T>
    where T : BaseEntity
{
    private readonly CarRentalContext _dbContext;

    protected DbSet<T> Table => _dbContext.Set<T>();
    public EfGenericRepository(CarRentalContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(T entity)
    {
        var addedState = await Table.AddAsync(entity);
        return addedState.State == EntityState.Added;
    }

    public async Task<List<T>> GetAllAsync(bool tracking = true)
    {
        if (tracking is false)
        {
            return await Table.AsNoTracking().ToListAsync();
        }
        return await Table.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id) => await Table.FindAsync(id);

    public async Task<List<T>> GetWhere(Expression<Func<T, bool>> expression)
        => await Table.Where(expression).ToListAsync();

    public bool Remove(T entity)
    {
        var removed = Table.Remove(entity);
        return removed.State == EntityState.Deleted;
    }

    public bool Update(T entity)
    {
        var updated = Table.Update(entity);
        return updated.State == EntityState.Modified;
    }
}
