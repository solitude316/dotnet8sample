using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace API.Middlewares;
public class MyFirstMiddleware
{
    private readonly ILogger _logger;
    
    private readonly RequestDelegate _next;

    public MyFirstMiddleware(ILogger logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("In our custom Middlare...");
        // Prepare work for when we write to the Response.

        await _next(context);
        // Work that happends when we Do write to the response.
    }
}