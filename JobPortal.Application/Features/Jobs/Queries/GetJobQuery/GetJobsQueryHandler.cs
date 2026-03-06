using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.Jobs.Queries.GetJobQuery
{
    public class GetJobsQueryHandler
        : IRequestHandler<GetJobsQuery, IQueryable<JobDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetJobsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IQueryable<JobDto>> Handle(
            GetJobsQuery request,
            CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Job>();
            var query = repo.GetAll().Select(j => new JobDto
            {
                Id = j.Id,
                Title = j.Title,
                SalaryFrom = j.SalaryFrom,
                SalaryTo = j.SalaryTo,
                JobLocation = j.JobLocation,
                JobType = j.JobType,
                ExperienceLevel = j.ExperienceLevel,
                ApplicationDeadline = j.ApplicationDeadline,
            });

            return Task.FromResult(query);
        }
    }
}
