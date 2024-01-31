namespace Project.Core.Models.Requests
{
    /// <summary>
    /// Paging request model
    /// </summary>
    public record BasePagingRequest
    {
        /// <summary>
        /// Page number
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// Page size
        /// </summary>
        public int PageLength { get; set; } = 10;

        /// <summary>
        /// Keyword for search
        /// </summary>
        public string? Keyword { get; set; }
    }
}
