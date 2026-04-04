using Microsoft.EntityFrameworkCore;
using Coffeeg.Data;

namespace Coffeeg.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration config)
        {
            return services.AddDbContext<CoffeegDbContext>((serviceProvider, opts) =>
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                opts.UseSqlServer(connectionString);
            });
        }
    }
}
