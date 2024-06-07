using System.Security.Cryptography;
using API.Extensions;
using API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Map("/map1", HandleMapTest1);




app.Map("/level1", level1App => {
    level1App.Map("/level2a", async level2AApp => {
        level2AApp.Run(async context => {
            await context.Response.WriteAsync("in /level1/level2a");
        });
    });
});

// app.MapWhen(context => context.Request.Query.ContainsKey)

static void HandleMapTest1(IApplicationBuilder app) 
{
    app.Run(async context=> {
        await context.Response.WriteAsync("Map Test 1");
    });
}


// Middlewares out of box.
app.UseClientOptions();

// app.UseHttpsRedirection(); // Move to WebApplicationExtensions


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
