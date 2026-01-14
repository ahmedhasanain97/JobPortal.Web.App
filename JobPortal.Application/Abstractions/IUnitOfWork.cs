namespace JobPortal.Application.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IAsyncRepository<T, TId> Repository<T, TId>() where T : class;
        IUserRepo UserRepository { get; }
    }
}