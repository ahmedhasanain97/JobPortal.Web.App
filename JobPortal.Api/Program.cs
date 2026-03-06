using JobPortal.Api.Middlewares;
using JobPortal.Application.Common.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<LogRequestFilter>();
})
.AddOData(options =>
{
    var odataBuilder = new ODataConventionModelBuilder();

    odataBuilder.EntitySet<JobDto>("Jobs");

    options
        .AddRouteComponents("odata", odataBuilder.GetEdmModel())
        .Filter()
        .Select()
        .OrderBy()
        .Expand()
        .Count()
        .SetMaxTop(100);
});

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "JobPortal.API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });


    options.AddSecurityRequirement(document =>
        new OpenApiSecurityRequirement
        {
            [
                new OpenApiSecuritySchemeReference("Bearer", document)
            ] = Array.Empty<string>().ToList()
        }
    );
});


builder.Services.AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices()
    .AddApiServicesRegisteration(builder.Configuration);


// Serilog as default logger
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "JobPortal.API v1");
        c.InjectJavascript("/js/swagger-jwt.js"); // save login token in local storage
    });
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("Frontend");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.Run();