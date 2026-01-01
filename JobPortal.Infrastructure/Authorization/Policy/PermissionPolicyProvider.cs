using JobPortal.Application.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace JobPortal.Infrastructure.Authorization.Policy
{
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
            => Task.FromResult(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
            => Task.FromResult<AuthorizationPolicy?>(null);

        // we are inside the policy provider with input "JobSeeker.Read"
        // now follow the request
        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (string.IsNullOrWhiteSpace(policyName) || !policyName.Contains("."))
                return Task.FromResult<AuthorizationPolicy?>(null);

            var parts = policyName.Split('.');
            var module = parts[0];
            var permission = parts[1];

            var policy = new AuthorizationPolicyBuilder()
                .AddRequirements(new PermissionRequirement(module, permission))
                .Build();
            return Task.FromResult<AuthorizationPolicy?>(policy);
        }
    }
}
