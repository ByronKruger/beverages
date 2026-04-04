using Coffeeg.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Coffeeg.Extensions
{
    public static class JwtBearerMiddlewareExtension
    {
        public static IServiceCollection AddJwtBearerMiddleware(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    var tokenKey = config["TokenKey"] ?? throw new CoffeegMissingConfigurationException("Cannot find token key");
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true, // essential -- validates that token is valid (else any token accepted)
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                        ValidateIssuer = false, // not necessary for now -- validates that tokens only sent by specific issuer
                        ValidateAudience = false // not necessary for now -- as to who the audience is
                    };
                });
            
            return services;
        }
    }
}
