namespace JobPortal.Application.Features.ApplicationUsers.Commands.SoftDeleteUser
{
    public record SoftDeleteUserCommand(string userId) : IRequest<Result>
    {
    }
}
