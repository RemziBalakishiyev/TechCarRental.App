using CarRental.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace CarRental.Persistance.EntityFrameworks.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CarRentalContext _context;
    private readonly Dictionary<Type, object> _repositories;

    public UnitOfWork(CarRentalContext context)
    {
        _repositories = new Dictionary<Type, object>();
        _context = context;
        _context.Database.BeginTransactionAsync();
    }

    public ICarRepository CarRepository => SetRepository<ICarRepository>();

    public ICategoryRepository CategoryRepository => SetRepository<ICategoryRepository>();

    public IUserRepository UserRepository =>SetRepository<IUserRepository>();

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
        await _context.Database.CommitTransactionAsync();
    }



    public TRepository GetRepository<TRepository>() where TRepository : class
    {
        throw new NotImplementedException();
    }

    public void Rollback()
    {


        foreach (var entry in _context.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Deleted:
                    entry.Reload();
                    break;
            }
        }
    }


    public TRepository SetRepository<TRepository>()
    {
        if (_repositories.ContainsKey(typeof(TRepository)))
        {
            return (TRepository)_repositories[typeof(TRepository)];
        }

        var repositoryType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => !x.IsInterface && x.IsClass && x.IsAssignableTo(typeof(TRepository)));

        var repositoryInstance = (TRepository)Activator.CreateInstance(repositoryType, _context);
        _repositories.Add(typeof(TRepository), repositoryInstance);
        return repositoryInstance;
    }
}
