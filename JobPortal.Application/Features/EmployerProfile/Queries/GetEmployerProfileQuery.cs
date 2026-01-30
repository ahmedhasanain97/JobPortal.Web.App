namespace JobPortal.Application.Features.EmployerProfile.Queries
{
    public sealed record GetEmployerProfileQuery(string userId) : IRequest<Result<EmployerDto>>
    {
    }
}
