using Project.Core.Models;

namespace Project.Models.Parameters.CostCenters
{
    public record CostCenterGetAllParameter : BasePagingParameter, IGetAllCostCenterParameter
    {
        public string? CostCenterName { get; set; }
        public string? SapName { get; set; }
        public string? SapDesc { get; set; }
        public string? Note { get; set; }
        public int? PositionId { get; set; }
    }
}
