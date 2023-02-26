using System.Net;

namespace coIT.BewirbDich.Api.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly ILogger logger;
    private readonly RequestDelegate next;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}