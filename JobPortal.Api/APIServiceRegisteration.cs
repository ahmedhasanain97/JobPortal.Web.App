using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace JobPortal.Api
{
    public static class APIServiceRegisteration
    {
        public static IServiceCollection AddApiServicesRegisteration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.MSSqlServer(
                    connectionString: configuration.GetConnectionString("DefaultConnection"),
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        AutoCreateSqlDatabase = false,
                        TableName = "Logs",
                    },
                    columnOptions: new ColumnOptions
                    {
                        AdditionalColumns = new[] { new SqlColumn("RequestId", SqlDbType.NVarChar, dataLength: 64) }
                    })
                .CreateLogger();
            #endregion
            #region Cors
            var origins = configuration
                .GetSection("Cors:Origins")
                .Get<string[]>();
            services.AddCors(options =>
            {
                options.AddPolicy("Frontend", builder =>
                {
                    builder.WithOrigins(origins!)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            #endregion
            #region Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JWT:Key"]!)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            #endregion
            
            return services;
        }
    }
}
