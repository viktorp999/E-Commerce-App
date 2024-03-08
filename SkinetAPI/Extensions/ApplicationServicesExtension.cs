using Microsoft.EntityFrameworkCore;
using SkinetCore.Interfaces;
using SkinetInfrastructure.Data;

namespace SkinetAPI.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddDbContext<StoreContext>(opt => opt.UseSqlServer(config.GetConnectionString("SkinetConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
