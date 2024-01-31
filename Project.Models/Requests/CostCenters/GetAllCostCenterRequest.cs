using Project.Core.Models.Requests;

namespace Project.Models.Requests.CostCenters
{
    public record GetAllCostCenterRequest : BasePagingRequest
    {
        public int? Id { get; set; }
        public string? CostCenterName { get; set; }
        public string? SapName { get; set; }
        public string? SapDesc { get; set; }
        public string? Note { get; set; }
        public int? PositionId { get; set; }
    }
}
