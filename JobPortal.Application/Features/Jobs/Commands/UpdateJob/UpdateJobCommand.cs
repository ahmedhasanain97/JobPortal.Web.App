using JobPortal.Domain.Enums;

namespace JobPortal.Application.Features.Jobs.Commands.UpdateJob
{
    public record UpdateJobCommand(
         Guid JobId,
         string? Title,
         string? Description,
         JobLocation? JobLocation,
         JobType? JobType,
         string? ExperienceLevel,
         double? SalaryFrom,
         double? SalaryTo,
         DateTime? ApplicationDeadline,
            string UserId
     ) : IRequest<Result<UpdateJobDto>>;


}
