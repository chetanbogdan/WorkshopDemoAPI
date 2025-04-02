using Microsoft.AspNetCore.Mvc.Filters;

namespace WorkshopDemoAPI.Filters;

public class SynchronousCustomFilter(ILogger<SynchronousCustomFilter> logger) : IActionFilter
{
    private readonly ILogger<SynchronousCustomFilter> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public void OnActionExecuting(ActionExecutingContext context)
    {
        logger.LogInformation("Synchronous Filter Executing before action");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        logger.LogInformation("Synchronous Filter Executing after action");
    }
}