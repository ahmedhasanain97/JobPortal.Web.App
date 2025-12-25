namespace JobPortal.Infrastructure.Configurations
{
    public class JobSeekerProfileConfigurations : IEntityTypeConfiguration<JobSeekerProfile>
    {
        public void Configure(EntityTypeBuilder<JobSeekerProfile> builder)
        {
            builder.ToTable("JobSeekerProfiles");
            builder.HasKey(jsp => jsp.Id);
            builder.Property(jsp => jsp.UserId)
                   .IsRequired();
            builder.Property(jsp => jsp.FullName)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(jsp => jsp.ResumeUrl)
                   .HasMaxLength(250);
            builder.Property(jsp => jsp.Title)
                   .HasMaxLength(100);
            builder.Property(jsp => jsp.Summary)
                     .HasMaxLength(2000);
            builder.HasIndex(jsp => jsp.UserId)
                   .IsUnique();
            builder.HasOne(jsp => jsp.User)
                   .WithOne(u => u.JobSeekerProfile)
                   .HasForeignKey<JobSeekerProfile>(jsp => jsp.UserId)
                   .HasPrincipalKey<User>(u => u.Id)
                   .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
