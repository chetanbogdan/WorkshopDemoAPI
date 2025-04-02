using Microsoft.AspNetCore.Mvc.Filters;

namespace WorkshopDemoAPI.Filters;

public class AsynchronousAttributeCustomFilter : Attribute, IAsyncActionFilter
{
    private readonly string _callerName;

    public AsynchronousAttributeCustomFilter(string callerName)
    {
        _callerName = callerName;
    }
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        
        Console.WriteLine($"Asynchronous Attribute Filter Executing before action - {_callerName}");
        await next();
        Console.WriteLine($"Asynchronous Attribute Filter Executing after action - {_callerName}");
    }
}