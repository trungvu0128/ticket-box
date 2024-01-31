using System.Net.Mail;
using System.Text;

namespace Shared.Email
{
    public class SendMail : ISendMail
    {
        private readonly SmtpClient _smtpClient;
        public SendMail(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendAsync(EmailRequest emailRequest)
        {
            var message = GetMailMessage(emailRequest);
            await _smtpClient.SendMailAsync(message);
        }

        private MailMessage GetMailMessage(EmailRequest request)
        {
            MailMessage mailMessage = new()
            {
                From = new MailAddress(request.FromEmail),
                Subject = request.Subject,
                Body = request.Body,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
            };
            switch (request.High)
            {
                case 273:
                    mailMessage.Priority = MailPriority.Low;
                    break;
                case 275:
                    mailMessage.Priority = MailPriority.High;
                    break;
                default:
                    mailMessage.Priority = MailPriority.Normal;
                    break;
            }

            //to email
            for (int i = 0; i < request.ToEmail?.Count; i++)
            {
                mailMessage.To.Add(request.ToEmail[i].ToString());
            }

            //cc email
            for (int i = 0; i < request.CcEmail?.Count; i++)
            {
                mailMessage.CC.Add(request.CcEmail[i].ToString());
            }

            //attachment
            for (int i = 0; i < request.Attachment?.Count; i++)
            {
                mailMessage.Attachments.Add(new Attachment(request.Attachment[i].ToString()));
            }
            return mailMessage;
        }
    }
}
