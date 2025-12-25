namespace JobPortal.Infrastructure.Configurations
{
    public class JobApplicationConfigurations : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("JobApplications");
            builder.HasKey(ja => ja.Id);
            builder.Property(ja => ja.ApplicationDate)
                   .IsRequired();
            builder.Property(ja => ja.Status)
                   .IsRequired()
                   .HasConversion<string>();
            builder.HasIndex(ja => new { ja.JobId, ja.JobSeekerProfileId })
                   .IsUnique();
            builder.HasOne(ja => ja.Job)
                   .WithMany(j => j.JobApplications)
                   .HasForeignKey(ja => ja.JobId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
