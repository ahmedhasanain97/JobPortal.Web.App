using JobPortal.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.Jobs.Commands.SoftDeleteJob
{
    public class SoftDeleteJobCommandHandler : IRequestHandler<SoftDeleteJobCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SoftDeleteJobCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(SoftDeleteJobCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Job>();
            var job = await repo.FindByIdAsync(request.jobId);
            if (job == null)
                return Result.Failure(new Error("JobNotFound", "The job with the specified ID was not found."));
            if (job.ApplicationUserId != request.userId)
                return Result.Failure(Error.Unauthorized("You are not authorized to delete this job."));

            repo.SoftDelete(job);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result == 0)
                return Result.Failure(Error.BadRequest("DeletionFailed"));

            return Result.Success();
        }
    }
}
