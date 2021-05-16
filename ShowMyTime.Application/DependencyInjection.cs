using ShowMyTime.Application.Interfaces;
using ShowMyTime.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ShowMyTime.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IJsonService, JsonService>();
            services.AddTransient<ITimeService, TimeService>();
            services.AddTransient<IWorldTimeApiService, WorldTimeApiService>();

            return services;
        }
    }
}