namespace Shared.ORM.Models
{
    /// <summary>
    /// Paging response
    /// </summary>
    /// <typeparam name="TPaging"></typeparam>
    public class Paging<TPaging>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalCount"></param>
        /// <param name="totalPage"></param>
        public Paging(IEnumerable<TPaging> items, int totalCount, int totalPage)
        {
            Items = items;
            TotalCount = totalCount;
            TotalPage = totalPage;
        }

        /// <summary>
        /// Items in paging
        /// </summary>
        public IEnumerable<TPaging> Items { get; set; }

        /// <summary>
        /// Total count
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Total page
        /// </summary>
        public int TotalPage { get; set; }
    }
}
