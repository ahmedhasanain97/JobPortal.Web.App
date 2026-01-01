using JobPortal.Application.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace JobPortal.Infrastructure.Authorization.Handlers
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PermissionAuthorizationHandler(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            // user checks
            var userId = context.User.Claims.Where(claim => claim.Type == "UserId").FirstOrDefault()?.Value;
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return;

            // role checks
            var roleClaim = context.User.Claims.Where(claim => claim.Type == ClaimTypes.Role).FirstOrDefault()?.Value;



                if (roleClaim == null || !await _userManager.IsInRoleAsync(user, roleClaim))
                return;


                if (roleClaim == "Admin")
                {
                    context.Succeed(requirement);
                    return;
                }

            // role access checks
            var roleAccess = _context.RoleAccessModules
                .Include(ram => ram.Role)
                .Include(ram => ram.Module)
                .Where(ram => ram.Role.Name == roleClaim &&
                    ram.Module.Name == requirement.Module)
                .FirstOrDefault();

            if (roleAccess == null)
                return;

            // permission checks
            var hasPermission = requirement.Permission switch
            {
                "Read" => roleAccess.CanRead,
                "Write" => roleAccess.CanWrite,
                "Delete" => roleAccess.CanDelete,
                _ => false
            };

            if (!hasPermission)
                return;

            context.Succeed(requirement);
        }
    }
}
