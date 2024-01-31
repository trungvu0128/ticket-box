namespace Project.Core.Models
{
    public record BasePagingParameter
    {
        /// <summary>
        /// Filter by id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Page number
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageLength { get; set; }
    }
}
