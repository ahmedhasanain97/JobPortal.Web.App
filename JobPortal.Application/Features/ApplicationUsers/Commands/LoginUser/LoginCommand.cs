using JobPortal.Application.Abstractions;
using MediatR;

namespace JobPortal.Application.Features.ApplicationUsers.Commands.LoginUser
{
    public record LoginCommand
    (
    string Email,
    string Password
    ) : IRequest<Result>;
}
