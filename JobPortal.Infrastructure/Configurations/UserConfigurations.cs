namespace JobPortal.Infrastructure.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(25);

        }
    }
}
