using JobPortal.Domain.Enums;

namespace JobPortal.Application.Common.Models
{
    public class ApplicationDto
    {
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public string JobSeekerName { get; set; }
        public string CvUrl { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
