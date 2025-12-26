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

            return services;
        }
    }
}
