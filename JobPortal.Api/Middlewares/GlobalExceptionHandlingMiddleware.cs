using JobPortal.Api.Services;
using JobPortal.Application.Exceptions;

namespace JobPortal.Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var traceId = context.TraceIdentifier;

            ApiErrorResponse response;
            int statusCode;

            switch (exception)
            {
                case ValidationException ve:
                    Log.Error("Validation error occurd with exception {0} on request {1}", exception, traceId);
                    statusCode = StatusCodes.Status400BadRequest;

                    response = new ApiErrorResponse
                    {
                        StatusCode = statusCode,
                        Message = ve.Message,
                        Errors = ve.Errors,
                        TraceId = traceId
                    };
                    break;

                case BusinessException be:
                    Log.Error(exception, "Business rule violation"); // not structred
                    statusCode = StatusCodes.Status400BadRequest;

                    response = new ApiErrorResponse
                    {
                        StatusCode = statusCode,
                        Message = be.Message,
                        ErrorCode = be.ErrorCode,
                        TraceId = traceId
                    };
                    break;

                case NotFoundException nf:
                    Log.Error("Resource not found for request {0} with exception {1}", traceId, nf);
                    statusCode = StatusCodes.Status404NotFound;

                    response = new ApiErrorResponse
                    {
                        StatusCode = statusCode,
                        Message = nf.Message,
                        TraceId = traceId
                    };
                    break;

                default:
                    Log.Fatal(exception, "Unhandled system exception"); // or actually it is but you have to log the exception
                    statusCode = StatusCodes.Status500InternalServerError;

                    response = new ApiErrorResponse
                    {
                        StatusCode = statusCode,
                        Message = "an error occurred",
                        TraceId = traceId
                    };
                    break;
            }

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
