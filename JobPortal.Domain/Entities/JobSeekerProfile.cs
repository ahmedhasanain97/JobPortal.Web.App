using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain.Entities
{
    public class JobSeekerProfile : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public int? YearsOfExperience { get; set; }
        public string? ResumeUrl { get; set; }
        public ICollection<JobSeekerSkillSet> JobSeekerSkills { get; set; } = new List<JobSeekerSkillSet>();

    }
}
