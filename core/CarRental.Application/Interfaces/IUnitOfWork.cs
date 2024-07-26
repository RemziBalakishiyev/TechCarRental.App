namespace CarRental.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
        void Rollback();

        TRepository SetRepository<TRepository>();
        TRepository GetRepository<TRepository>() where TRepository : class;

        ICarRepository CarRepository { get; }
        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; }
    }
}
