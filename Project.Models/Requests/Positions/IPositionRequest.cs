namespace Project.Models.Requests.Positions
{
    public interface IPositionRequest
    {
        public string? PositionName { get; set; }

        public int? ParentId { get; set; }

        public string? Note { get; set; }

        public int? Status { get; set; }
    }
}
