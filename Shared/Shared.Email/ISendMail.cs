namespace Shared.Email
{
    public interface ISendMail
    {
        Task SendAsync(EmailRequest emailRequest);
    }
}
