
namespace API.Extensions;

public class EmojiMiddleware
{
    private readonly RequestDelegate _next;

    public EmojiMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        using var buffer = new MemoryStream();
        var stream = context.Response.Body;
        context.Response.Body = buffer;

        await _next(context);
        buffer.Seek(0, SeekOrigin.Begin);
        var emojiStream = new EmojiStream(stream);
        buffer.Seek(0, SeekOrigin.Begin);
        
        await buffer.CopyToAsync(emojiStream);
        context.Response.Body = emojiStream;
    }
}