namespace JobPortal.Api.Services
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; init; }
        public string Message { get; init; } = default!;
        public string TraceId { get; init; } = default!;
        public string? ErrorCode { get; init; }
        public IDictionary<string, string[]>? Errors { get; init; }
    }
}
