using Microsoft.Extensions.DependencyInjection;
using TestTask.Infrastructure.Repositories;
using TestTask.WebApi.Core.Data;

namespace TestTask.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ISettingRepository, SettingRepository>()
                .AddScoped<IUserAttemptRepository, UserAttemptRepository>();
        }
    }
}
