namespace JobPortal.Application.Features.EmployerProfile.Commands
{
    public record UpdateEmployerProfileCommand(string userId, string? FirstName, string? LastName, string? CompanyName) : IRequest<Result<UpdateEmployerProfileDto>>
    {
    }
}
