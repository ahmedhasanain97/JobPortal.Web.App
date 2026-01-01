using JobPortal.Application.Abstractions;
using JobPortal.Application.Common.Interfaces;
using JobPortal.Infrastructure.Authorization.Handlers;
using JobPortal.Infrastructure.Authorization.Policy;
using JobPortal.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;


namespace JobPortal.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext and Identity Configuration
            services.AddIdentityCore<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddDbContext<AppDbContext>(cfg => cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #endregion

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // AuthorizationPolicy Handlers
            //services.AddAuthorizationCore();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

            return services;
        }
    }
}
