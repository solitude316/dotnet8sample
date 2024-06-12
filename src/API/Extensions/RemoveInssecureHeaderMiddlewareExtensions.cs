using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Middlewares;

namespace API.Extensions;

public static class RemoveInssecureHeaderMiddlewareExtensions
{
    public static IApplicationBuilder RemoveInsecureHeaders (this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RemoveInsecureHeaderMiddleware>();
    }
}