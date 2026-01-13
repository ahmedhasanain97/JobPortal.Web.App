using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.ApplicationUsers.Queries.GetUsers
{
    public sealed record GetUsersQuery(int pageNumber = 1, int pageSize = 10) : IRequest<Result<PaginatedResult<UserDto>>>
    {

    }
}
