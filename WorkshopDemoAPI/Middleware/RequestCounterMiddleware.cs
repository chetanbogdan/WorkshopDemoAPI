using WorkshopDemoAPI.Services;

namespace WorkshopDemoAPI.Middleware;

public class RequestCounterMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next ?? throw new ArgumentNullException(nameof(next));

    public async Task Invoke(HttpContext context, IClientCreditSystem clientCreditSystem)
    {
        var apiKey = context.Request.Query["api_key"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            await context.Response.WriteAsync("API Key is required.");
            return;
        }
        
        var clientCanContinue = await clientCreditSystem.CheckClientCredit(apiKey);
        if (!clientCanContinue)
        {
            await context.Response.WriteAsync("You don't have credits left");
            return;
        }
        
        // Call the next delegate/middleware in the pipeline
        await _next(context);
        
        // I can execute code here as well that happens after we're returning the response 
        // But, I shouldn't make changes to the response as it could cause unintended behaviour 
    }
}

public static class ClientCreditMiddlewareExtensions
{
    public static IApplicationBuilder UseClientCreditMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestCounterMiddleware>();
    }
}