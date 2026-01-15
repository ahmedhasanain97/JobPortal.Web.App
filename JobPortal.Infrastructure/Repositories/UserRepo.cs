using JobPortal.Application.Abstractions;

namespace JobPortal.Infrastructure.Repositories
{
    public class UserRepo : BaseRepository<ApplicationUser>, IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void UpdateUserAsync(ApplicationUser user, string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
                user.FirstName = firstName;

            if (!string.IsNullOrWhiteSpace(lastName))
                user.LastName = lastName;

        }
    }
}
