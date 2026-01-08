using System.Diagnostics.CodeAnalysis;

namespace JobPortal.Application.Abstractions
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error? Error { get; }
        protected Result(bool isSuccess, Error? error)
        {
            if (isSuccess && error != null)
                throw new ArgumentException("Invalid Argument.", nameof(error));
            if (!isSuccess && error == null)
                throw new ArgumentException("Invalid Argument.", nameof(error));
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, null);
        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, null);
        public static Result Failure(Error error) => new Result(false, error);
        public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default, false, error);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue? _value;
        public Result(TValue? value, bool isSuccess, Error? error)
            : base(isSuccess, error)
        {
            _value = value;
        }


        [NotNull]
        public TValue? Value => IsSuccess ? _value! : default!;

        public static implicit operator Result<TValue>(TValue? value)
            => value != null ? Success(value) : Failure<TValue>(Error.Null);
    }
}
