using Microsoft.EntityFrameworkCore;
using SkinetInfrastructure.Data;
using SkinetAPI.Extensions;
using SkinetAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<MiddlewareException>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.Seed(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error has occured during migration.");
}

app.Run();
