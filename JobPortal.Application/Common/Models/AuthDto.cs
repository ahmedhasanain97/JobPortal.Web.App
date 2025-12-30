namespace JobPortal.Application.Common.Models
{
    public class AuthDto
    {
        public string Message { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; } = null!;
        public string email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public IList<string> Roles { get; set; } = null!;
        public DateTime ExpiresOn { get; set; }

    }
}
