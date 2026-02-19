namespace JobPortal.Application.Abstractions
{
    public interface IJobRepo : IAsyncRepository<Job>
    {
        Task UpdateJobAsync(UpdateJobDto updateJobDto);
    }
}
