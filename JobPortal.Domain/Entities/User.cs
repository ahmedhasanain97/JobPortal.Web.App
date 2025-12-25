namespace JobPortal.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public JobSeekerProfile? JobSeekerProfile { get; set; }
        public EmployerProfile? EmployerProfile { get; set; }
    }
}
