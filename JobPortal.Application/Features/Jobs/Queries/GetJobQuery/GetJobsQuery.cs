namespace JobPortal.Application.Features.Jobs.Queries.GetJobQuery
{


    public record GetJobsQuery()
        : IRequest<IQueryable<JobDto>>;
}
