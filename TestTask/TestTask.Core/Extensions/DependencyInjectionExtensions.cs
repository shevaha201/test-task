using Microsoft.Extensions.DependencyInjection;
using TestTask.WebApi.Core.Handlers;

namespace TestTask.Core.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<IGetUsersHandler, GetUsersHandler>()
                .AddScoped<IGetRangeSettingsHandler, GetRangeSettingsHandler>()
                .AddScoped<IGetUserAttemptsHandler, GetUserAttemptsHandler>()
                .AddScoped<IAddUserAttemptHandler, AddUserAttemptsHandler>();
        }
    }
}
