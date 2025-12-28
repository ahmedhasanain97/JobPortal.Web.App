using Microsoft.AspNetCore.Identity;

namespace JobPortal.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public UserType UserType { get; set; }
        public string? CompanyName { get; set; }
        public string? CVURL { get; set; }
    }
}
