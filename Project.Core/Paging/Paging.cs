namespace Project.Core.Paging
{
    public sealed class Paging<T> : IPaging<T>
    {
        private readonly int _totalPage;
        private readonly int _totalRow;
        private readonly IEnumerable<T> _items;
        public Paging(IEnumerable<T> items, int totalCount, int totalPage)
        {
            _items = items;
            _totalRow = totalCount;
            _totalPage = totalPage;
        }

        public IEnumerable<T> Items { get => _items; }
        public int TotalRow { get => _totalRow; }
        public int TotalPage { get => _totalPage; }
    }
}
