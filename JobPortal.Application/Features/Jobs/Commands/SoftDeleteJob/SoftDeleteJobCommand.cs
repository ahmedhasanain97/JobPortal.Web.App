using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.Jobs.Commands.SoftDeleteJob
{
    public record SoftDeleteJobCommand(Guid jobId, string userId) : IRequest<Result>
    {
    }
}
