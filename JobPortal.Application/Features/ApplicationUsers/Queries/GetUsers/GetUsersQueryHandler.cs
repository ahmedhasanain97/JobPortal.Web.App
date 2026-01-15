using JobPortal.Application.Extensions;

namespace JobPortal.Application.Features.ApplicationUsers.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<PaginatedResult<UserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PaginatedResult<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<ApplicationUser>();
            var query = repo.GetAll().Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName!,
                Email = u.Email!,
                FirstName = u.FirstName,
                LastName = u.LastName,
            });

            var paginatedQuery = await query.ToPaginatedResultAsync(request.pageNumber, request.pageSize, cancellationToken);

            if (!paginatedQuery.Items.Any())
                return Result.Failure<PaginatedResult<UserDto>>(Error.NotFound("No More Data to Show"));

            return Result.Success(paginatedQuery);
        }

    }

}
