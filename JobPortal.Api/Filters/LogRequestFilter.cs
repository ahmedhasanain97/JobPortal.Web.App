namespace JobPortal.Api.Filters
{
    public class LogRequestFilter : IActionFilter
    {
        // todo: log request details before and after action execution
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
