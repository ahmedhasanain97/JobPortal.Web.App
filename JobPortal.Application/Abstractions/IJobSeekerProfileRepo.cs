namespace JobPortal.Application.Abstractions
{
    public interface IJobSeekerProfileRepo : IAsyncRepository<ApplicationUser>
    {
        Task UpdateJobSeekerProfile(UpdateJobSeekerProfileDto updateJobSeekerProfileDto);
    }
}
