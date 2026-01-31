using JobPortal.Application.Common.Behaviours;
using JobPortal.Application.Features.ApplicationUsers.Commands.RegisterUser;
using JobPortal.Application.Features.Jobs.Commands.CreateJob;
using System.Reflection;


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
                cfg.RegisterServicesFromAssembly(
                    typeof(RegisterUserCommand).Assembly);
            });
            #region Fluent Validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion
            services.AddTransient(
               typeof(IPipelineBehavior<,>),
               typeof(ValidationBehaviour<,>)
);
            return services;
        }
    }
}
