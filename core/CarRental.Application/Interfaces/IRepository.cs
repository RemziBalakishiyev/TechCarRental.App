using CarRental.Domain.Entities.Common;
using System.Linq.Expressions;

namespace CarRental.Application.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync(bool tracking = true);
    Task<T> GetByIdAsync(int id);
    Task<bool> AddAsync(T entity);
    bool Update(T entity);
    bool Remove(T entity);
    Task<List<T>> GetWhere(Expression<Func<T, bool>> expression);
}
