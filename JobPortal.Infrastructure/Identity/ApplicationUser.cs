namespace JobPortal.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public JobSeekerProfile? JobSeekerProfile { get; set; }
        public EmployerProfile? EmployerProfile { get; set; }
    }
}
