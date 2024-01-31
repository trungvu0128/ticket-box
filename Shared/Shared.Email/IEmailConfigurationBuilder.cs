using System.Net.Mail;

namespace Shared.Email
{
    public interface IEmailConfigurationBuilder
    {
        IEmailConfigurationBuilder UseDefaultCredential(bool isDefault);
        IEmailConfigurationBuilder WithCredentials(string userName, string password);
        IEmailConfigurationBuilder EnabledSSL(bool isEnabled);
        SmtpClient Build();
    }
}
