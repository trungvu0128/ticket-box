using Project.Core.Models.Responses;

namespace Project.Models.Responses.Positions
{
    public record PositionResponse : BaseResponse
    {
        public string PositionName { get; set; } = null!;

        public int? ParentId { get; set; }

        public string? Note { get; set; }

        public int Status { get; set; }
    }
}
