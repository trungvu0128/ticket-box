using Project.Core.Models.Responses;

namespace Project.Models.Responses.CostCenters
{
    public record CostCenterPagingResponse : BasePagingResponse
    {
        public string CostCenterName { get; set; } = null!;

        public string? SapName { get; set; }

        public string? SapDesc { get; set; }

        public string? Note { get; set; }

        public int LocationId { get; set; }

        public int Id { get; set; }
    }
}
