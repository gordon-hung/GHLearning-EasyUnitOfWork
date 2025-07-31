using Microsoft.Extensions.DependencyInjection;

namespace GHLearning.EasyUnitOfWork.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEasyUnitOfWork(this IServiceCollection services, Action<MySqlConnectionOptions, IServiceProvider> mySqlConnectionOptions)
    => services
        .AddOptions<MySqlConnectionOptions>()
        .Configure(mySqlConnectionOptions)
        .Services
        .AddSingleton<IMySqlConnectionFactory, MySqlConnectionFactory>()
        .AddScoped<IUnitOfWork, UnitOfWork>();
}
