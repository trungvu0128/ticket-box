namespace Project.Core.Models.Responses
{
    public record BaseResponse
    {
        public int Id { get; set; }
        public string CreateBy { get; set; } = default!;
        public DateTime CreateDate { get; set; } = default!;
        public string? UpdateBy { get; set; } = default!;
        public DateTime? UpdateDate { get; set; } = default!;
    }
}
