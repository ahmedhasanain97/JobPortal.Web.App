namespace JobPortal.Infrastructure.Context
{

    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); // Apply all configurations from the current assembly
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .ToTable("Users");

            builder.Entity<IdentityRole>()
                .ToTable("Roles");

            builder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");

            builder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims");

            builder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins");

            builder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaims");

            builder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.IsActive = true;
                        entry.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
