using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkinetCore.Entities.Identity;
using SkinetInfrastructure.Identity;

namespace SkinetAPI.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("IdentityConnection"));
            });
            services.AddIdentityCore<AppUser>(options =>
            {

            }).AddEntityFrameworkStores<AppIdentityDbContext>().AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();
            services.AddAuthorization();

            return services;
        }
    }
}
