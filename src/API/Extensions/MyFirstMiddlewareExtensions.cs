using API.Middlewares;

namespace API.Extensions;

public static class MyFirstMiddlewareExtensions
{
    public static IApplicationBuilder UseMyFirstMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyFirstMiddleware>();
    }
}