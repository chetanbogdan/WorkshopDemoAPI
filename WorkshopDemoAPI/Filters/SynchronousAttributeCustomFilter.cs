using Microsoft.AspNetCore.Mvc.Filters;

namespace WorkshopDemoAPI.Filters;

public class SynchronousAttributeCustomFilter : Attribute, IActionFilter
{
    private readonly string _callerName;

    public SynchronousAttributeCustomFilter(string callerName)
    {
        _callerName = callerName;
    }
    
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"Synchronous Attribute Filter Executing before action - {_callerName}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"Synchronous Attribute Filter Executing after action - {_callerName}");
    }
}