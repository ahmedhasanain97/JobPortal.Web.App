namespace JobPortal.Infrastructure.Configurations
{
    public class JobSkillSetConfigurations : IEntityTypeConfiguration<JobSkillSet>
    {
        public void Configure(EntityTypeBuilder<JobSkillSet> builder)
        {
            builder.ToTable("JobsSkillSet");
            builder.HasKey(js => new { js.JobId, js.SkillId });
            builder.HasIndex(js => new { js.JobId, js.SkillId })
                   .IsUnique();
            builder.Property(js => js.IsMandatory)
                   .IsRequired();
            builder.Property(js => js.YearsOfExperienceRequired);

        }
    }
}
