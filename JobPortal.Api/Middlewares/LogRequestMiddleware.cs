namespace JobPortal.Api.Middlewares
{
    public class LogRequestMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var requestId = context.TraceIdentifier;
            using (LogContext.PushProperty("RequestId", requestId))
            {
                await next(context);
            }
        }
    }
}
