namespace JobPortal.Application.Features.JobApplications.Queries.ListApplicationsPerJob
{
    public sealed record ListApplicationsPerJobQuery(Guid Id, int pageNumber = 1, int pageSize = 10) : IRequest<Result<PaginatedResult<JobApplication>>>
    {

    }
}
