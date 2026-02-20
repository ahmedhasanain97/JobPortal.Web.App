using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.Jobs.Queries.GetJobById
{
    public record GetJobByIdQuery(Guid jobId) : IRequest<Result<JobDto>>
    {
    }
}
