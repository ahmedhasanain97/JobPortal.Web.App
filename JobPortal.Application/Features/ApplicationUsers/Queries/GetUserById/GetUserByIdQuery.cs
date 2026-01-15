using MediatR;

namespace JobPortal.Application.Features.ApplicationUsers.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(string userId) : IRequest<Result<UserDto>>
    {
    }
}
