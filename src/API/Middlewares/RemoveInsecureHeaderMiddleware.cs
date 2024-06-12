using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace API.Middlewares;
public class RemoveInsecureHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public RemoveInsecureHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Response.OnStarting((state) => {
            context.Response.Headers.Remove("Server");
            context.Response.Headers.Remove("X-Powered-By");
            context.Response.Headers.Remove("X-Aspnet-Version");
            context.Response.Headers.Remove("X-AspnetMvc-Version");
            
            context.Response.Headers.Add("X-Content-Type-Option", new StringValues("nosniff"));
            context.Response.Headers.Add("X-Frame-Options", new StringValues("DENY"));
        
            return Task.CompletedTask;
        }, null!);
        await _next(context);
    }
        
}