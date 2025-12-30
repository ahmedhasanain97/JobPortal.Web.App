namespace JobPortal.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<AuthDto> RegisterAsync(
        string firstName,
        string lastName,
        string username,
        string email,
        string password);

        Task<AuthDto> LoginAsync(
            string email,
            string password);
    }
}
