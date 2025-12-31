using Microsoft.AspNetCore.Authorization;

namespace JobPortal.Api.Authorization.Attributes
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string module, string permission)
        {
            Policy = $"{module}.{permission}";
        }
    }
}
