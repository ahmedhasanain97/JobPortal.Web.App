using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.JobSeekerProfiles.Queries.GetJobSeekerProfile
{
    public sealed record GetJobSeekerPofileQuery(string userId) : IRequest<Result<JobSeekerDto>>
    {

    }
}
