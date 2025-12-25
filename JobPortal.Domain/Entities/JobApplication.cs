namespace JobPortal.Domain.Entities
{
    public class JobApplication : AuditableEntity
    {
        public Guid Id { get; set; }
        public Job Job { get; set; } = null!;
        public Guid JobId { get; set; }
        public JobSeekerProfile JobSeekerProfile { get; set; } = null!;
        public Guid JobSeekerProfileId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }

    }
}
