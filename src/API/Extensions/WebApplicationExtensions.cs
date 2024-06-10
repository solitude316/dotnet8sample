using API.Middlewares;
namespace API.Extensions;
public static class WebApplicationExtension
{
    public static void UseClientOptions(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();
    }
}