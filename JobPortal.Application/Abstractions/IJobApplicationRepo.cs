namespace JobPortal.Application.Abstractions
{
    public interface IJobApplicationRepo : IAsyncRepository<JobApplication>
    {
        Task<bool> HasUserAppliedToJob(Guid jobId, string userId);
        Task CreateApplication(Guid jobId, string userId);
    }
}
