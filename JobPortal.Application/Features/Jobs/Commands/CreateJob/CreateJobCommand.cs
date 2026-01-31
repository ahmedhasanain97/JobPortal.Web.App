using JobPortal.Domain.Enums;

namespace JobPortal.Application.Features.Jobs.Commands.CreateJob
{
    public record CreateJobCommand(
        string EmployerId,
        string Title,
        string Description,
        JobLocation JobLocation,
        JobType JobType,
        string? ExperienceLevel,
        double SalaryFrom,
        double SalaryTo,
        DateTime ApplicationDeadline
    ) : IRequest<Result>;
}
