
using Coffeeg.Exceptions;
using Coffeeg.Extensions;
using Coffeeg.Helpers.AutoMapperProfiles;
using Coffeeg.Interfaces.Repositories;
using Coffeeg.Interfaces.Services;
using Coffeeg.Repositories;
using Coffeeg.Services;

namespace Coffeeg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDataContext(builder.Configuration); // configure ef and db provider 

            builder.Services.AddIdentityCore(); // configure asp identity

            builder.Services.AddJwtBearerMiddleware(builder.Configuration); // configure jwt-based middleware

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            builder.Services.AddAutoMapper(typeof(BeverageCustomisationProfiles));   // scans for profiles in that assembly
            builder.Services.AddAutoMapper(typeof(UserProfile));   // scans for profiles in that assembly

            builder.Services.AddScoped<IAdminBeverageManagementService, AdminBeverageManagementService>();
            builder.Services.AddScoped<IAdminBeverageManagementRepository, AdminBeverageManagementRepository>();

            builder.Services.AddScoped<IBeverageCustomisationRepository, BeverageCustomisationRepository>();
            builder.Services.AddScoped<IBeverageCustomisationService, BeverageCustomisationService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserManagementService, UserManagementService>();

            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddPolicyBasedAuthorization();

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler();

            app.UseAuthorization();
            app.UseAuthentication();// this was omitted yet app auth worked?*

            app.MapControllers();

            app.Run();
        }
    }
}
