using JobPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Job> Jobs { get; }
        DbSet<JobSkillSet> JobsSkillSet { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
