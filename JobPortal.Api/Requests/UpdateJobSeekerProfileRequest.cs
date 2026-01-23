using JobPortal.Application.Common.Models;

namespace JobPortal.Api.Requests
{
    public class UpdateJobSeekerProfileRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CVURL { get; set; }
        public List<SkillDto>? SkillSet { get; set; }
    }
}
