namespace JobPortal.Domain.Entities
{
    public class EmployerProfile : AuditableEntity
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = null!;
        public EmployerType EmployerType { get; set; }
        public string DisplayName { get; set; } = null!;
        public string? WebsiteUrl { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public int? NumberOfEmployees { get; set; }
        public string? CompanyDescription { get; set; } = string.Empty;
        public ICollection<Job> Jobs { get; set; } = new List<Job>();

    }
}
