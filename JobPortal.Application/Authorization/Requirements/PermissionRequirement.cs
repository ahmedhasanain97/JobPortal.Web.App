using Microsoft.AspNetCore.Authorization;

namespace JobPortal.Application.Authorization.Requirements
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Module { get; set; }
        public string Permission { get; set; }

        public PermissionRequirement(string module, string permission)
        {
            Module = module;
            Permission = permission;
        }
    }
}
