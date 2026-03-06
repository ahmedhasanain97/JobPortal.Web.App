using JobPortal.Application.Abstractions;
using JobPortal.Domain.Enums;

namespace JobPortal.Infrastructure.Repositories
{
    public class JobApplicationRepo : BaseRepository<JobApplication>, IJobApplicationRepo
    {
        private readonly AppDbContext _context;
        public JobApplicationRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> HasUserAppliedToJob(Guid jobId, string userId)
        {
            return await _context.JobApplications
                .AnyAsync(x => x.JobId == jobId && x.ApplicationUserId == userId);
        }
        public async Task CreateApplication(Guid jobId, string userId)
        {
            var jobApplication = new JobApplication
            {
                Id = Guid.NewGuid(),
                JobId = jobId,
                ApplicationUserId = userId,
                ApplicationDate = DateTime.UtcNow,
                Status = ApplicationStatus.Pending
            };
            await _context.JobApplications.AddAsync(jobApplication);
        }
    }
}
