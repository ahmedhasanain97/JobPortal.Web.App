using Microsoft.AspNetCore.Identity;

namespace JobPortal.Domain.Entities
{
    public class ApplicationUser : IdentityUser, ISoftDeletable
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? CVURL { get; set; }
        public virtual ICollection<JobSeekerSkillSet> JobSeekerSkillSet { get; set; } = new List<JobSeekerSkillSet>();
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}
