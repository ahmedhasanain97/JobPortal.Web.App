namespace JobPortal.Application.Abstractions
{
    public interface IEmployerProfileRepo : IAsyncRepository<ApplicationUser>
    {
        Task UpdateEmployerProfile(UpdateEmployerProfileDto updateEmployerProfileDto);
    }
}
