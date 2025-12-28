namespace JobPortal.Infrastructure.Configurations
{
    public class RoleAccessModuleConfigurations : IEntityTypeConfiguration<RoleAccessModule>
    {
        public void Configure(EntityTypeBuilder<RoleAccessModule> builder)
        {
            builder.Property(builder => builder.ModuleId)
                   .IsRequired();

            builder.Property(builder => builder.RoleId)
                   .IsRequired();

            builder.Property(builder => builder.CanRead)
                   .IsRequired();

            builder.Property(builder => builder.CanWrite)
                   .IsRequired();

            builder.Property(builder => builder.CanUpdate)
                   .IsRequired();

            builder.Property(builder => builder.CanDelete)
                   .IsRequired();
        }
    }
}
