namespace JobPortal.Infrastructure.Configurations
{
    public class SkillConfigurations : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasIndex(s => s.Name)
                   .IsUnique();

        }

    }
}
