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
        public IQueryable<ApplicationUser> GetUsersByRole(string roleName)
        {
            var query = from user in _context.Users
                        join userRole in _context.UserRoles on user.Id equals userRole.UserId
                        join role in _context.Roles on userRole.RoleId equals role.Id
                        where role.Name == roleName
                        select user;
            return query.AsNoTracking();
        }
    }
}
