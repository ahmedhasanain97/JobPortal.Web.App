namespace JobPortal.Application.Abstractions
{
    public interface IJobSeekerProfileRepo : IAsyncRepository<ApplicationUser>
    {
        Task UpdateJobSeekerProfileRepo(UpdateJobSeekerProfileDto updateJobSeekerProfileDto);
    }
}
