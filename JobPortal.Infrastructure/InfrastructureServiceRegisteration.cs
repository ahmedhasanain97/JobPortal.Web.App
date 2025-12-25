namespace JobPortal.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext and Identity Configuration
            services.AddIdentityCore<User>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddDbContext<AppDbContext>(cfg => cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #endregion

            return services;
        }
    }
}
