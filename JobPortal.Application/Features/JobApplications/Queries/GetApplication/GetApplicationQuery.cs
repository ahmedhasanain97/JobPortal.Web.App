namespace JobPortal.Application.Features.JobApplications.Queries.GetApplication
{
    public sealed record GetApplicationQuery(Guid applicationId, string employerId) : IRequest<Result<ApplicationDto>>
    {
    }
}
