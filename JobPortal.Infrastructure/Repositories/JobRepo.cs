using JobPortal.Application.Abstractions;
using JobPortal.Application.Common.Models;

namespace JobPortal.Infrastructure.Repositories
{
    public class JobRepo : BaseRepository<Job>, IJobRepo
    {
        private readonly AppDbContext _context;
        public JobRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task UpdateJobAsync(UpdateJobDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var job = await _context.Jobs.FindAsync(dto.Id);

            if (job == null)
                throw new Exception("Job not found");
            if (job.ApplicationUserId != dto.UserId)
                throw new Exception("Unauthorized");

            if (!string.IsNullOrWhiteSpace(dto.Title))
                job.Title = dto.Title;

            if (!string.IsNullOrWhiteSpace(dto.Description))
                job.Description = dto.Description;

            if (dto.JobLocation.HasValue)
                job.JobLocation = dto.JobLocation.Value;

            if (dto.JobType.HasValue)
                job.JobType = dto.JobType.Value;

            if (!string.IsNullOrWhiteSpace(dto.ExperienceLevel))
                job.ExperienceLevel = dto.ExperienceLevel;

            if (dto.SalaryFrom.HasValue)
                job.SalaryFrom = dto.SalaryFrom.Value;

            if (dto.SalaryTo.HasValue)
                job.SalaryTo = dto.SalaryTo.Value;

            if (dto.ApplicationDeadline.HasValue)
                job.ApplicationDeadline = dto.ApplicationDeadline.Value;

        }

    }
}
