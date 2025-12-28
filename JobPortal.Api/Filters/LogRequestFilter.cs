namespace JobPortal.Api.Filters
{
    public class LogRequestFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
            => Log.Information("Ending execution on Controller: {0} action: {1}", context.Controller, context.ActionDescriptor.DisplayName);

        public void OnActionExecuting(ActionExecutingContext context)
            => Log.Information("Starting execution on Controller: {0} action: {1}", context.Controller, context.ActionDescriptor.DisplayName);
    }
}
