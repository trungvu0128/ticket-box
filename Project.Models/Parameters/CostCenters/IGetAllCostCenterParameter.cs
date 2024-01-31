using Project.Core.Models.Parameters;

namespace Project.Models.Parameters.CostCenters
{
    public interface IGetAllCostCenterParameter : IBasePagingParameter, IParameter
    {
        public string? CostCenterName { get; set; }
        public string? SapName { get; set; }
        public string? SapDesc { get; set; }
        public string? Note { get; set; }
        public int? PositionId { get; set; }
    }
}
