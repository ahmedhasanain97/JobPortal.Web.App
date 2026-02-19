using JobPortal.Domain.Enums;

namespace JobPortal.Application.Common.Models
{
    public class UpdateJobDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public JobLocation? JobLocation { get; set; }
        public JobType? JobType { get; set; }
        public string? ExperienceLevel { get; set; }
        public double? SalaryFrom { get; set; }
        public double? SalaryTo { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
        public string UserId { get; set; } = null!;
    }
}
