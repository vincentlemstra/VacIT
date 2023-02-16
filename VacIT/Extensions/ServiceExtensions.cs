using LoggerService;

namespace VacIT.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin() // More restrictive: WithOrigins("http://www.example.com")
                    .AllowAnyMethod() // More restrictive: WithMethods("POST", "GET")
                    .AllowAnyHeader()); // More restrictive: WithHeaders("accept", "content-type")
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
