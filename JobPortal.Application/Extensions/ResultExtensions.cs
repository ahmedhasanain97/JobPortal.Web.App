using JobPortal.Application.Abstractions;

namespace JobPortal.Application.Extensions
{
    public static class ResultExtensions
    {
        public static TOut Match<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> onSuccess, Func<Error, TOut> onFailure)
        {
            return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Error!);
        }
    }
}
