using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WorkshopDemoAPI.Handlers;

public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService = problemDetailsService ?? throw new ArgumentNullException(nameof(problemDetailsService));
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                Title = "An unexpected error occurred",
                Detail = exception.Message,
                Type = "Internal Server Error",
            };
        
            return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                ProblemDetails = problemDetails,
            });
        }
        
        var validationProblemDetails = new ProblemDetails
        {
            Title = "Validation exception",
            Status = StatusCodes.Status400BadRequest,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
            Detail = "One or more validation errors occurred.",
            Type = "Bad Request",
            Extensions = { ["errors"] = validationException.Errors }
        };

        httpContext.Response.StatusCode = validationProblemDetails.Status.Value;
        return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = validationProblemDetails,
        });
    }
}