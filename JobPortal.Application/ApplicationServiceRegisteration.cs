using JobPortal.Application.Jobs.Commands.CreateJob;

namespace JobPortal.Application
{
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(
                    typeof(CreateJobCommand).Assembly
                );
            });
            return services;
        }
    }
}
