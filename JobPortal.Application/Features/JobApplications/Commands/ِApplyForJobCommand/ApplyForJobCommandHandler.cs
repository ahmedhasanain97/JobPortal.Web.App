namespace JobPortal.Application.Features.JobApplications.Commands._ِApplyForJobCommand
{
    public class ApplyForJobCommandHandler : IRequestHandler<ApplyForJobCommand, Result>
    {
        private readonly IJobApplicationRepo _jobApplicationRepo;
        private readonly IUnitOfWork _unitOfWork;
        public ApplyForJobCommandHandler(IJobApplicationRepo jobApplicationRepo, IUnitOfWork unitOfWork)
        {
            _jobApplicationRepo = jobApplicationRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ApplyForJobCommand request, CancellationToken cancellationToken)
        {
            if (await _jobApplicationRepo.HasUserAppliedToJob(request.jobId, request.userId))
                return Error.Conflict("You have already applied for this job");

            await _jobApplicationRepo.CreateApplication(request.jobId, request.userId);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0)
                return Result.Success("Application submitted successfully");
            return Result.Failure(Error.BadRequest("Failed to submit Application"));

        }
    }
}
