using JobPortal.Domain.Enums;
using MediatR;

namespace JobPortal.Application.Jobs.Commands.CreateJob
{
    public class CreateJobCommand : IRequest<Guid>
    {
        public Guid EmployerProfileId { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public JobLocation JobLocation { get; set; }
        public JobType JobType { get; set; }
        public JobStatus JobStatus { get; set; }
        public String? ExperienceLevel { get; set; }

        public double SalaryFrom { get; set; }
        public double SalaryTo { get; set; }
        public DateTime ApplicationDeadline { get; set; }
    }
}
