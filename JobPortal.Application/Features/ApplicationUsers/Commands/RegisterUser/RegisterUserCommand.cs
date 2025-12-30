using MediatR;

namespace JobPortal.Application.Features.ApplicationUsers.Commands.RegisterUser
{
    public record RegisterUserCommand(
        string FirstName,
        string LastName,
        string Username,
        string Email,
        string Password) : IRequest<AuthDto>;
}
