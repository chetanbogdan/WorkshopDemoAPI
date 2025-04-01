namespace WorkshopDemoAPI.Middleware;

public class CorrelationIdMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next ?? throw new ArgumentNullException(nameof(next));

    public async Task Invoke(HttpContext context)
    {
        context.Response.Headers.Append("X-Correlation-ID", Guid.NewGuid().ToString());
        
        // Call the next delegate/middleware in the pipeline
        await _next(context);
        
        // I can execute code here as well that happens after we're returning the response 
        // But, I shouldn't make changes to the response as it could cause unintended behaviour 
    }
}

public static class CorrelationIdMiddlewareExtensions
{
    public static IApplicationBuilder UseCorrelationIdMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CorrelationIdMiddleware>();
    }
}