namespace JobPortal.Application.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IAsyncRepository<T> Repository<T>() where T : class;
        IUserRepo UserRepository { get; }
        IJobSeekerProfileRepo JobSeekerProfileRepository { get; }
        IEmployerProfileRepo EmployerProfileRepository { get; }
    }
}