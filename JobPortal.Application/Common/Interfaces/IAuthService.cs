using JobPortal.Application.Abstractions;

namespace JobPortal.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<Result<AuthDto>> RegisterAsync(
        string firstName,
        string lastName,
        string username,
        string email,
        string password);

        Task<Result<AuthDto>> LoginAsync(
            string email,
            string password);
    }
}
