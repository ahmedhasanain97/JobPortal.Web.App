namespace JobPortal.Application.Features.Jobs.Commands.UpdateJob
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, Result<UpdateJobDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateJobCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<UpdateJobDto>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.JobRepository;
            var dto = new UpdateJobDto
            {
                Id = request.JobId,
                Title = request.Title,
                Description = request.Description,
                JobLocation = request.JobLocation,
                JobType = request.JobType,
                ExperienceLevel = request.ExperienceLevel,
                SalaryFrom = request.SalaryFrom,
                SalaryTo = request.SalaryTo,
                ApplicationDeadline = request.ApplicationDeadline,
                UserId = request.UserId
            };
            await repo.UpdateJobAsync(dto);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result <= 0)
                return Result.Failure<UpdateJobDto>(Error.BadRequest("Failed To Update Job"));
            return Result.Success(dto);

        }
    }
}
