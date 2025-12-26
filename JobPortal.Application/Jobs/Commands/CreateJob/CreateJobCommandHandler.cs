using JobPortal.Application.Common.Interfaces;
using JobPortal.Domain.Entities;
using JobPortal.Domain.Enums;
using MediatR;

namespace JobPortal.Application.Jobs.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, Guid>
    {
        private readonly IAppDbContext _context;
        public CreateJobCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job
            {
                EmployerProfileId = request.EmployerProfileId,
                Title = request.Title,
                Description = request.Description,
                JobLocation = request.JobLocation,
                JobType = request.JobType,
                ExperienceLevel = request.ExperienceLevel,
                SalaryFrom = request.SalaryFrom,
                SalaryTo = request.SalaryTo,
                ApplicationDeadline = request.ApplicationDeadline,
                Jobstatus = request.JobStatus,

            };
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync(cancellationToken);
            return job.Id;
        }
    }
}
