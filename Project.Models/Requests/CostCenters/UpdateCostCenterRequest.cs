using Project.Core.Models.Requests;

namespace Project.Models.Requests.CostCenters
{
    public record UpdateCostCenterRequest : BaseUpdateRequest
    {
        public string CostCenterName { get; set; } = default!;
        public string SapName { get; set; } = default!;
        public string SapDesc { get; set; } = default!;
        public string Note { get; set; } = default!;
        public int? PositionId { get; set; }
    }
}
