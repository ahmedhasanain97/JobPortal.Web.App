

namespace JobPortal.Infrastructure.Configurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(u => u.CompanyName)
                .HasMaxLength(50);
            builder.Property(u => u.UserType)
                .IsRequired()
                .HasConversion<string>();

        }
    }
}
