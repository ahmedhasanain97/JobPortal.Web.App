using JobPortal.Application.Extensions;

namespace JobPortal.Application.Features.JobApplications.Queries.ListApplicationsPerJob
{
    public class ListApplicationsPerJobQueryHandler : IRequestHandler<ListApplicationsPerJobQuery, Result<PaginatedResult<JobApplication>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListApplicationsPerJobQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PaginatedResult<JobApplication>>> Handle(ListApplicationsPerJobQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<JobApplication>();
            var query = repo.GetAll().Where(u => u.JobId == request.Id);


            var paginatedQuery = await query.ToPaginatedResultAsync(request.pageNumber, request.pageSize, cancellationToken);

            if (!paginatedQuery.Items.Any())
                return Result.Failure<PaginatedResult<JobApplication>>(Error.NotFound("No Data to Show"));

            return Result.Success(paginatedQuery);
        }
    }
}
