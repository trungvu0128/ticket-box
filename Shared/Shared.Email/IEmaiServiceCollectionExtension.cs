using Microsoft.Extensions.DependencyInjection;

namespace Shared.Email
{
    public static class IEmaiServiceCollectionExtension
    {
        public static void UseMailService(this IServiceCollection service, EmailConfiguration configuration)
        {
            var client = new EmailConfigurationBuilder(configuration.Host, configuration.Port)
                .UseDefaultCredential(configuration.UseDefaultCredentials)
                .WithCredentials(configuration.UserName, configuration.Password)
                .EnabledSSL(configuration.IsEnabledSsl)
                .Build();
            service.AddSingleton<ISendMail, SendMail>(x => new SendMail(client));
        }
    }
}
