using Coffeeg.Data;
using Coffeeg.Entities;
using Microsoft.AspNetCore.Identity;

namespace Coffeeg.Extensions
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentityCore(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CoffeegDbContext>();

            return services;
        }
        
        public static IServiceCollection AddPolicyBasedAuthorization(this IServiceCollection services)
        {
            services.AddAuthorizationBuilder()
                .AddPolicy("Admin", policy => policy.RequireRole("Admin"))
                .AddPolicy("Moderator", policy => policy.RequireRole("Admin", "Moderator"));

            return services;
        }
    }
}
