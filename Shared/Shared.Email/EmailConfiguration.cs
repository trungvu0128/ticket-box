namespace Shared.Email
{
    public class EmailConfiguration
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public bool IsEnabledSsl { get; set; }
    }
}
