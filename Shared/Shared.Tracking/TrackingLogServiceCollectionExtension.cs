using Microsoft.Extensions.DependencyInjection;

namespace Shared.Tracking
{
    public static class TrackingLogServiceCollectionExtension
    {
        public static void UseTrackingLog(this IServiceCollection services)
        {
            services.AddSingleton<ITrackingLog, TrackingLog>();
        }
    }
}
