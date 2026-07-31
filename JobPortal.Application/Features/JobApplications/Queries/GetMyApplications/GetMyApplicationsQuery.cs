using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.JobApplications.Queries.GetMyApplications
{
    public sealed record GetMyApplicationsQuery(string Id, int pageNumber = 1, int pageSize = 10) : IRequest<Result<PaginatedResult<JobApplication>>>
    {

    }
}
