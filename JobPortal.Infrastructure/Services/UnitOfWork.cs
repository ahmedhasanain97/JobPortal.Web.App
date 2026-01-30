using JobPortal.Application.Abstractions;
using JobPortal.Application.Exceptions;
using JobPortal.Infrastructure.Repositories;

namespace JobPortal.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
            => _context = context;

        public IAsyncRepository<T> Repository<T>() where T : class
            => new BaseRepository<T>(_context);
        public IUserRepo UserRepository
            => new UserRepo(_context);
        public IJobSeekerProfileRepo JobSeekerProfileRepository
            => new JobSeekerProfileRepo(_context);
        public IEmployerProfileRepo EmployerProfileRepository
            => new EmployerProfileRepo(_context);

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                var affectedRows = await _context.SaveChangesAsync();
                return affectedRows;
            }
            catch (Exception ex) when (ex is DbUpdateException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
    }
}