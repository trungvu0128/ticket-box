using System.Net.Mail;
using System.Net;

namespace Shared.Email
{
    public class EmailConfigurationBuilder : IEmailConfigurationBuilder
    {
        protected SmtpClient? _smtpClient;
        private string? Host;
        private int Port;
        private NetworkCredential? Credential;
        private bool UseDefaultCredentials = false;
        private bool IsEnabledSsl = false;

        public EmailConfigurationBuilder(string? host, int port)
        {
            Host = host;
            Port = port;
        }

        public IEmailConfigurationBuilder UseDefaultCredential(bool isDefault)
        {
            UseDefaultCredentials = isDefault;
            return this;
        }

        public IEmailConfigurationBuilder WithCredentials(string userName, string password)
        {
            Credential = new NetworkCredential(userName, password);
            return this;
        }

        public IEmailConfigurationBuilder EnabledSSL(bool isEnabled)
        {
            IsEnabledSsl = isEnabled;
            return this;
        }



        public SmtpClient Build()
        {
            if (_smtpClient == null)
            {
                _smtpClient = new SmtpClient(Host, Port);
                _smtpClient.EnableSsl = IsEnabledSsl;
                _smtpClient.Credentials = Credential;
                _smtpClient.UseDefaultCredentials = UseDefaultCredentials;
            }
            return _smtpClient;
        }
    }
}
