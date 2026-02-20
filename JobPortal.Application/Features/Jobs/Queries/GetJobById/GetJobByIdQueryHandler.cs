namespace JobPortal.Application.Features.Jobs.Queries.GetJobById
{
    public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, Result<JobDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetJobByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<JobDto>> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Job>();
            var job = await repo.FindByIdAsync(request.jobId);
            if (job == null)
                return Result.Failure<JobDto>(Error.NotFound("Job Not Found"));
            var jobDto = new JobDto
            {
                Title = job.Title,
                Description = job.Description,
                JobLocation = job.JobLocation,
                JobType = job.JobType,
                ExperienceLevel = job.ExperienceLevel,
                SalaryFrom = job.SalaryFrom,
                SalaryTo = job.SalaryTo,
                ApplicationDeadline = job.ApplicationDeadline
            };
            return Result.Success(jobDto);
        }
    }
}
