using MailApi;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddMailService(this IServiceCollection services, Action<SMTPOptions> config)
    {
        services.Configure<SMTPOptions>(config);
        services.AddSingleton<Sender>();
        return services;
    }
}
