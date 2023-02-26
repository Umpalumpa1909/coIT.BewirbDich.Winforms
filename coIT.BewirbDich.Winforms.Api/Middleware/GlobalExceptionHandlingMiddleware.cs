using Microsoft.Extensions.Logging;
using System.Net;

namespace coIT.BewirbDich.Winforms.Api.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger logger;

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