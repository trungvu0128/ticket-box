namespace Project.Models.Responses
{
    public record CostCenterResponse
    {
        public string CostCenterName { get; set; } = null!;

        public string? SapName { get; set; }

        public string? SapDesc { get; set; }

        public string? Note { get; set; }

        public int? PositionId { get; set; }
    }
}
