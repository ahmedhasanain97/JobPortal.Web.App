namespace JobPortal.Domain.Entities
{
    public class Job : AuditableEntity
    {
        public Guid Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public String ApplicationUserId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public JobLocation JobLocation { get; set; }
        public JobType JobType { get; set; }
        public string ExperienceLevel { get; set; } = null!;
        public double SalaryFrom { get; set; }
        public double SalaryTo { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public JobStatus Jobstatus { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; }
        public ICollection<JobSkillSet> JobSkills { get; set; }
    }
}
