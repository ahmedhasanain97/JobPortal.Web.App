using System.Linq.Expressions;


namespace JobPortal.Infrastructure.Context
{

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<JobSkillSet> JobsSkillSet => Set<JobSkillSet>();
        public DbSet<Log> Logs { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<RoleAccessModule> RoleAccessModules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); // Apply all configurations from the current assembly
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
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
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, nameof(ISoftDeletable.IsDeleted));
                    var condition = Expression.Equal(property, Expression.Constant(false));
                    var lambda = Expression.Lambda(condition, parameter);

                    builder.Entity(entityType.ClrType)
                           .HasQueryFilter(lambda);
                }
            }
            base.OnModelCreating(builder);
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
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = DateTime.UtcNow;
                        break;

                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
