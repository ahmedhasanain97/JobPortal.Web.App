using JobPortal.Domain.Enums;

namespace JobPortal.Application.Features.JobApplications.Queries.GetApplication
{
    public class GetApplicationQueryHandler : IRequestHandler<GetApplicationQuery, Result<ApplicationDto>>
    {
        private readonly IJobApplicationRepo _jobApplicationRepo;
        private readonly IUnitOfWork _unitOfWork;
        public GetApplicationQueryHandler(IJobApplicationRepo jobApplicationRepo, IUnitOfWork unitOfWork)
        {
            _jobApplicationRepo = jobApplicationRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ApplicationDto>> Handle(GetApplicationQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<JobApplication>();

            var application = await repo.FindByIdAsync(request.applicationId);

            if (application == null)
                return Result.Failure<ApplicationDto>(
                    Error.NotFound("Application Not Found"));

            var job = await _unitOfWork.Repository<Job>()
                .FindByIdAsync(application.JobId);

            if (job == null)
                return Result.Failure<ApplicationDto>(
                    Error.NotFound("Job Not Found"));

            if (job.ApplicationUserId != request.employerId)
                return Result.Failure<ApplicationDto>(
                    Error.Unauthorized("You are not authorized to view this application"));

            var jobSeeker = await _unitOfWork.Repository<ApplicationUser>()
                .FindByIdAsync(application.ApplicationUserId);

            if (jobSeeker == null)
                return Result.Failure<ApplicationDto>(
                    Error.NotFound("Job Seeker Not Found"));

            if (application.Status == ApplicationStatus.Pending)
            {
                await _jobApplicationRepo.UpdateApplicationStatus(
                    application.Id,
                    ApplicationStatus.Reviewed);

                application.Status = ApplicationStatus.Reviewed;
            }
            var applicationdto = new ApplicationDto
            {
                Id = application.Id,
                JobId = application.JobId,
                JobSeekerName = application.ApplicationUser?.FirstName + " " + application.ApplicationUser?.LastName,
                CvUrl = jobSeeker.CVURL!,
                ApplicationDate = application.ApplicationDate,
                Status = application.Status
            };
            return Result.Success(applicationdto);
        }

    }
}
