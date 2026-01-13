using Microsoft.AspNetCore.Identity;

namespace JobPortal.Domain.Entities
{
    public class ApplicationUser : IdentityUser, ISoftDeletable
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? CVURL { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedAt { get; set; }
        public void SoftDelete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            LockoutEnabled = true;
            LockoutEnd = DateTimeOffset.MaxValue;
        }

        public void Restore()
        {
            IsDeleted = false;
            DeletedAt = null;
            LockoutEnd = null;
        }
    }
}
