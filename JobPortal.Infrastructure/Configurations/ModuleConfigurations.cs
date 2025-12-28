namespace JobPortal.Infrastructure.Configurations
{
    internal class ModuleConfigurations : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .IsRequired(false)
                   .HasMaxLength(500);
        }
    }
}
