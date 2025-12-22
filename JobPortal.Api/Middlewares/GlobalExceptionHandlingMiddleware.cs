namespace JobPortal.Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
            }
			catch (Exception)
			{
                await HandleExceptionAsync(context);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context)
        {
            // todo: handle exceptions globally and return appropriate HTTP responses with status codes and error messages
            await Task.FromResult(100); // placeholder to avoid compiler warning
            throw new NotImplementedException();
        }
    }
}
