using Otter.API.Middlewares;
namespace Otter.API.Extensions;
public static class WebApplicationExtension
{
    public static void UseClientOptions(this WebApplication app)
    {
        // 
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
    }
}