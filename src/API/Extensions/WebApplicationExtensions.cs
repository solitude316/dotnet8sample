using API.Middlewares;
namespace API.Extensions;
public static class WebApplicationExtension
{
    public static void UseClientOptions(this WebApplication app)
    {
        // 
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.Use(async (context, next) => {
            context.Response.Headers.Remove("Server");
            context.Response.Headers.Remove("X-Powered-By");
            context.Response.Headers.Remove("X-Aspnet-Version");
            context.Response.Headers.Remove("X-AspNetMvc-Version");
            await next();
        });
    }
}