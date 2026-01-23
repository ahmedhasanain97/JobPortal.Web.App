using JobPortal.Application.Extensions;

namespace JobPortal.Application.Features.ApplicationUsers.Queries.GetUsersByRole
{
    public class GetUsersByRoleQueryHandler : IRequestHandler<GetUsersByRoleQuery, Result<PaginatedResult<UserDto>>>
    {
        private readonly IUserRepo _userRepo;
        public GetUsersByRoleQueryHandler(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<Result<PaginatedResult<UserDto>>> Handle(GetUsersByRoleQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.role))
            {
                return Result.Failure<PaginatedResult<UserDto>>(Error.Validation("Role cannot be null or empty"));
            }
            var usersInRole = _userRepo.GetUsersByRole(request.role);

            var userDtos = usersInRole.Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName!,
                Email = u.Email!,
                FirstName = u.FirstName,
                LastName = u.LastName,
            }).AsQueryable();
            var paginatedQuery = await userDtos.ToPaginatedResultAsync(request.pageNumber, request.pageSize, cancellationToken);
            if (!paginatedQuery.Items.Any())
                return Result.Failure<PaginatedResult<UserDto>>(Error.NotFound("No More Data to Show"));

            return Result.Success(paginatedQuery);

        }
    }
}
