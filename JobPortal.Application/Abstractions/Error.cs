namespace JobPortal.Application.Abstractions
{
    public record Error(string error, string? description = null)
    {
        public static Error None => new Error(string.Empty);
        public static Error NotFound(string message) => new Error("NotFound", message);
        public static Error Validation(string message) => new Error("Validation", message);
        public static Error Unauthorized(string message) => new Error("Unauthorized", message);
        public static Error Conflict(string message) => new Error("Conflict", message);
        public static Error Unexpected(string message) => new Error("Unexpected", message);
        public static Error BadRequest(string message) => new Error("BadRequest", message);
        public static Error Null => new Error("NullValue", "Value is Null.");
        public static implicit operator Result(Error error) => Result.Failure(error);
    }
}
