using MediatR;

namespace JobPortal.Application.Features.ApplicationUsers.Commands.UpdateUser
{
    public record UpdateUserCommand(
        string Id,
        string? FirstName,
        string? LastName
    ) : IRequest<Result<UpdateUserDto>>;
}
