namespace JobPortal.Application.Abstractions
{
    public interface IUserRepo : IAsyncRepository<ApplicationUser>
    {
        void UpdateUserAsync(ApplicationUser user, string firstName, string lastName);
    }
}
