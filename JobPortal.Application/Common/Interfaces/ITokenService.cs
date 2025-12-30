using JobPortal.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Application.Common.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user, UserManager<ApplicationUser> userManager);
    }
}
