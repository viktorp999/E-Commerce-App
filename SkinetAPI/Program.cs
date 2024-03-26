using Microsoft.EntityFrameworkCore;
using SkinetInfrastructure.Data;
using SkinetAPI.Extensions;
using SkinetAPI.Middleware;
using SkinetInfrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using SkinetCore.Entities.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<MiddlewareException>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var identityContext = services.GetRequiredService<AppIdentityDbContext>();
var userMenager = services.GetRequiredService<UserManager<AppUser>>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await identityContext.Database.MigrateAsync();
    await StoreContextSeed.Seed(context);
    await IdentitySeed.SeedUser(userMenager);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error has occured during migration.");
}

app.Run();
