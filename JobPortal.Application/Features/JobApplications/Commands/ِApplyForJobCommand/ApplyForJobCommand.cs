using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.JobApplications.Commands
{
    public record ApplyForJobCommand(string userId, Guid jobId) : IRequest<Result>
    {
    }
}
