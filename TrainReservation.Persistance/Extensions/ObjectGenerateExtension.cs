using Microsoft.Extensions.DependencyInjection;
using TrainReservation.Application;
using TrainReservation.Persistance.Services;

namespace TrainReservation.Persistance.Extensions
{
    public static class ObjectGenerateExtension
    {
        public static IServiceCollection AddObjectGenerate(this IServiceCollection services)
        {
            services.AddScoped<IReservationService, ReservationService>();
            return services;
        }
    }
}
