namespace JobPortal.Application.Common.Models
{
    public sealed class UserDto
    {
        public string Id { get; init; } = null!;
        public string UserName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
    }
}
