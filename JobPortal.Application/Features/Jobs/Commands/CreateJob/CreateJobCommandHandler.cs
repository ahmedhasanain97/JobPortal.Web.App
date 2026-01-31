namespace JobPortal.Application.Features.Jobs.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateJobCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job
            {
                ApplicationUserId = request.EmployerId,
                Title = request.Title,
                Description = request.Description,
                JobLocation = request.JobLocation,
                JobType = request.JobType,
                ExperienceLevel = request.ExperienceLevel!,
                SalaryFrom = request.SalaryFrom,
                SalaryTo = request.SalaryTo,
                ApplicationDeadline = request.ApplicationDeadline,

            };

            var repo = _unitOfWork.Repository<Job>();
            await repo.PostAsync(job);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result == 0)
            {
                return Result.Failure(Error.BadRequest("Failed to create job"));
            }
            return Result.Success();
        }

    }
}
