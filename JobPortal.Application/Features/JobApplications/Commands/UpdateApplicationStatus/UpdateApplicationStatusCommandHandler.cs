using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.JobApplications.Commands.UpdateApplicationStatus
{
    public class UpdateApplicationStatusCommandHandler : IRequestHandler<UpdateApplicationStatusCommand, Result<ApplicationDto>>
    {
        private readonly IJobApplicationRepo _jobApplicationRepo;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateApplicationStatusCommandHandler(IUnitOfWork unitOfWork, IJobApplicationRepo jobApplicationRepo)
        {
            _jobApplicationRepo = jobApplicationRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<ApplicationDto>> Handle(UpdateApplicationStatusCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<JobApplication>();
            var application = await repo.FindByIdAsync(request.applicationId);
            if (application == null)
                return Result.Failure<ApplicationDto>(Error.NotFound("Application Not Found"));
            var job = await _unitOfWork.Repository<Job>().FindByIdAsync(application.JobId);
            if (job == null)
                return Result.Failure<ApplicationDto>(Error.NotFound("Job Not Found"));
            if (job.ApplicationUserId != request.employerId)
                return Result.Failure<ApplicationDto>(Error.Unauthorized("You are not authorized to update this application"));
            var jobSeeker = await _unitOfWork.Repository<ApplicationUser>().FindByIdAsync(application.ApplicationUserId);
            if (jobSeeker == null)
                return Result.Failure<ApplicationDto>(Error.NotFound("Job Seeker Not Found"));
            await _jobApplicationRepo.UpdateApplicationStatus(application.Id, request.newStatus);
            return Result.Success(new ApplicationDto
            {
                Id = application.Id,
                JobId = application.JobId,
                JobSeekerName = jobSeeker.FirstName + " " + jobSeeker.LastName,
                CvUrl = jobSeeker.CVURL,
                ApplicationDate = application.ApplicationDate,
                Status = request.newStatus
            });
        }
    }
}
