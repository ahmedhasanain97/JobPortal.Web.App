namespace JobPortal.Application.Common.Models
{
    public class UpdateJobSeekerProfileDto
    {
        public string UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CVURL { get; set; }
        public List<SkillDto>? SkillSet { get; set; }
    }
}
