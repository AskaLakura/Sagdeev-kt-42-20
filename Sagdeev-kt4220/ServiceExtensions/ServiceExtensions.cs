using Sagdeev_kt4220.Interfaces;

namespace Sagdeev_kt4220.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPrepodService, PrepodService>();
            services.AddScoped<IStepenService, StepenService>();

            return services;
        }
    }
}
