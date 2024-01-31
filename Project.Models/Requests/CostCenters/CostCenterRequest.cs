namespace Project.Models.Requests.CostCenters
{
    public class CostCenterRequest
    {
        public string CostCenterName { get; set; } = null!;
        public string SapName { get; set; } = null!;
        public string SapDesc { get; set; } = null!;
        public string Note { get; set; } = null!;
        public int? PositionId { get; set; }
    }
}

