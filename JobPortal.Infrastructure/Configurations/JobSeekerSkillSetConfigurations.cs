namespace JobPortal.Infrastructure.Configurations
{
    public class JobSeekerSkillSetConfigurations : IEntityTypeConfiguration<JobSeekerSkillSet>
    {
        public void Configure(EntityTypeBuilder<JobSeekerSkillSet> builder)
        {
            builder.ToTable("JobSeekersSkillSet");
            builder.HasKey(jss => new { jss.ApplicationUserId, jss.SkillId });

        }
    }
}
