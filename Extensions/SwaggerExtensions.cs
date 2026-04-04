namespace Coffeeg.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerUI(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer(); // Register Swagger/OpenAPI generation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new()
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "Temporary interactive documentation for testing/demo"
                });
            });

            return services;
        }

    }
}
