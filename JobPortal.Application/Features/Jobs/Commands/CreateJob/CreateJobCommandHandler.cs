namespace JobPortal.Application.Features.Jobs.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateJobCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job
            {
                ApplicationUserId = request.ApplicationUserId,
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

            var repo = _unitOfWork.Repository<Job>();
            await repo.PostAsync(job);
            await _unitOfWork.SaveChangesAsync();
            return job.Id;
        }
    }
}
