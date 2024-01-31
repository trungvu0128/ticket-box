namespace Shared.Email
{
    public class EmailRequest
    {
        public required string FromEmail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public int? High { get; set; }
        public required List<string> ToEmail { get; set; }
        public List<string>? CcEmail { get; set; }
        public List<string>? Attachment { get; set; }
    }
}
