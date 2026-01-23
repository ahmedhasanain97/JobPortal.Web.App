using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.ApplicationUsers.Queries.GetUsersByRole
{
    public record GetUsersByRoleQuery(string role, int pageSize = 10, int pageNumber = 1) : IRequest<Result<PaginatedResult<UserDto>>>
    {
    }
}
