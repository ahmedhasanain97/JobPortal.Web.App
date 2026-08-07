using JobPortal.Application.Extensions;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Application.Features.JobApplications.Queries.GetMyApplications
{
    public class GetMyApplicationsQueryHandler : IRequestHandler<GetMyApplicationsQuery, Result<PaginatedResult<JobApplication>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetMyApplicationsQueryHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<Result<PaginatedResult<JobApplication>>> Handle(GetMyApplicationsQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<JobApplication>();
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return Result.Failure<PaginatedResult<JobApplication>>(Error.NotFound("User Not Found"));
            var query = repo.GetAll().Where(u => u.ApplicationUserId == request.Id);


            var paginatedQuery = await query.ToPaginatedResultAsync(request.pageNumber, request.pageSize, cancellationToken);

            if (!paginatedQuery.Items.Any())
                return Result.Failure<PaginatedResult<JobApplication>>(Error.NotFound("No Data to Show"));

            return Result.Success(paginatedQuery);
        }
    }
}
