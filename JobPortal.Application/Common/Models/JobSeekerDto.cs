namespace JobPortal.Application.Common.Models
{
    public class JobSeekerDto
    {
        public string UserId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CVUrl { get; set; } = string.Empty;
        public List<string> Skills { get; set; } = new List<string>();
    }
}
