using JobPortal.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Application.Features.JobApplications.Commands._ِApplyForJobCommand
{
    public class ApplyForJobCommandHandler : IRequestHandler<ApplyForJobCommand, Result>
    {
        private readonly IJobApplicationRepo _jobApplicationRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplyForJobCommandHandler(IJobApplicationRepo jobApplicationRepo, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _jobApplicationRepo = jobApplicationRepo;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Result> Handle(ApplyForJobCommand request, CancellationToken cancellationToken)
        {
            //check if user exists and is a job seeker
            var user = await _userManager.FindByIdAsync(request.userId);
            if (user == null)
                return Result.Failure(Error.NotFound("User not found"));
            var isJobSeeker = await _userManager.IsInRoleAsync(user, "JobSeeker");
            if (!isJobSeeker)
                return Result.Failure(Error.BadRequest("You can't apply to the job as Employer"));

            //check if job exists and is open for applications and user has not applied before
            var repo = _unitOfWork.JobRepository;
            var job = await repo.FindByIdAsync(request.jobId);
            if (job == null)
                return Result.Failure(Error.NotFound("Job not found"));
            if (job.Jobstatus != JobStatus.open)
                return Result.Failure(Error.BadRequest("This is not open for applications"));
            if (await _jobApplicationRepo.HasUserAppliedToJob(request.jobId, request.userId))
                return Result.Failure(Error.Conflict("You have already applied for this job"));

            await _jobApplicationRepo.CreateApplication(request.jobId, request.userId);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0)
                return Result.Success("Application submitted successfully");
            return Result.Failure(Error.BadRequest("Failed to submit Application"));

        }
    }
}
