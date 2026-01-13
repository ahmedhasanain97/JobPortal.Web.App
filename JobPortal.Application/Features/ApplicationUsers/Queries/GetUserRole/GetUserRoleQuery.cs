using MediatR;

namespace JobPortal.Application.Features.ApplicationUsers.Queries.GetUserRole
{
    public sealed record GetUserRoleQuery(string Id) : IRequest<Result<UserRoleDto>>
    {
    }
}
