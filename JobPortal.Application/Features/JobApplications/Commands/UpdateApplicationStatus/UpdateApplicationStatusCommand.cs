using JobPortal.Domain.Enums;

namespace JobPortal.Application.Features.JobApplications.Commands.UpdateApplicationStatus
{
    public sealed record UpdateApplicationStatusCommand(Guid applicationId, string employerId, ApplicationStatus newStatus) : IRequest<Result<ApplicationDto>>
    {
    }
}
