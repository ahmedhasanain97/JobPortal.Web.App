using JobPortal.Application.Abstractions;
using JobPortal.Application.Common.Models;

namespace JobPortal.Infrastructure.Repositories
{
    public class EmployerProfileRepo : BaseRepository<ApplicationUser>, IEmployerProfileRepo
    {
        private readonly AppDbContext _context;
        public EmployerProfileRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateEmployerProfile(UpdateEmployerProfileDto employerDto)
        {
            var updateuser = await _context.Users.FindAsync(employerDto.Id);
            if (employerDto == null)
                Error.NotFound("User Not Found");
            if (!string.IsNullOrWhiteSpace(employerDto.FirstName))
                updateuser.FirstName = employerDto.FirstName;
            if (!string.IsNullOrWhiteSpace(employerDto.LastName))
                updateuser.LastName = employerDto.LastName;
            if (!string.IsNullOrWhiteSpace(employerDto.CompanyName))
                updateuser.CompanyName = employerDto.CompanyName;
        }
    }
}
