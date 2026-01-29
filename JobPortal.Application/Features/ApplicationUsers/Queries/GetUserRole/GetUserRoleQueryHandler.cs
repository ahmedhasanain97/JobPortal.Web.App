using Microsoft.AspNetCore.Identity;

namespace JobPortal.Application.Features.ApplicationUsers.Queries.GetUserRole
{
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, Result<UserRoleDto>>
    {

        private readonly UserManager<ApplicationUser> _userManager;
        public GetUserRoleQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<UserRoleDto>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return Result.Failure<UserRoleDto>(Error.NotFound("User Not Found"));

            var roles = await _userManager.GetRolesAsync(user);
            return Result.Success(new UserRoleDto
            {
                Id = user.Id,
                Email = user.Email!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = roles.FirstOrDefault() ?? "No Role Assigned"
            });
        }
    }
}
