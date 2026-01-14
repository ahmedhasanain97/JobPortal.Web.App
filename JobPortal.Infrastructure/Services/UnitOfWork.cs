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

        public IAsyncRepository<T, TId> Repository<T, TId>() where T : class
            => new BaseRepository<T, TId>(_context);
        public IUserRepo UserRepository
            => new UserRepo(_context);

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