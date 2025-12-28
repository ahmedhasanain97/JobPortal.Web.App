namespace JobPortal.Infrastructure.Configurations
{
    public class JobConfigurations : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Title)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(j => j.Description)
                .IsRequired();
            builder.Property(j => j.JobLocation)
                   .IsRequired()
                   .HasConversion<string>();
            builder.Property(j => j.JobType)
                   .IsRequired()
                   .HasConversion<string>();
            builder.Property(j => j.ExperienceLevel)
                   .HasMaxLength(100)
                   .HasConversion<string>();
            builder.Property(j => j.Jobstatus)
                   .IsRequired()
                   .HasConversion<string>();
            builder.Property(j => j.SalaryFrom)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");
            builder.Property(j => j.SalaryTo)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");
            builder.Property(j => j.ApplicationDeadline)
                   .IsRequired();
            builder.HasIndex(j => j.ApplicationUserId);
            builder.HasOne(j => j.ApplicationUser)
                   .WithMany()
                   .HasForeignKey(j => j.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
