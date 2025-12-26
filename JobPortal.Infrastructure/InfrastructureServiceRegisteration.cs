using JobPortal.Application.Common.Interfaces;
using JobPortal.Infrastructure.Identity;

namespace JobPortal.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());
            #region DbContext and Identity Configuration
            services.AddIdentityCore<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddDbContext<AppDbContext>(cfg => cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #endregion

            return services;
        }
    }
}
