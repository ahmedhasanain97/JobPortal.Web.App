namespace JobPortal.Infrastructure.Configurations
{
    public class EmployerProfileConfigurations : IEntityTypeConfiguration<EmployerProfile>
    {
        public void Configure(EntityTypeBuilder<EmployerProfile> builder)
        {
            builder.ToTable("EmployerProfiles");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.UserId)
               .IsRequired();
            builder.Property(e => e.EmployerType)
                   .IsRequired()
                   .HasConversion<string>();
            builder.Property(e => e.DisplayName)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(e => e.WebsiteUrl)
                   .HasMaxLength(250);
            builder.Property(e => e.Industry)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(e => e.NumberOfEmployees);
            builder.Property(e => e.CompanyDescription)
                   .HasMaxLength(2000);
            builder.HasIndex(e => e.UserId)
                   .IsUnique();
            builder.HasMany(e => e.Jobs)
                   .WithOne(j => j.EmployerProfile)
                   .HasForeignKey(j => j.EmployerProfileId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.User)
                   .WithOne(u => u.EmployerProfile)
                   .HasForeignKey<EmployerProfile>(e => e.UserId)
                   .HasPrincipalKey<User>(u => u.Id)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
