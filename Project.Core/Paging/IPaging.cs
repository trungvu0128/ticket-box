namespace Project.Core.Paging
{
    public interface IPaging<T>
    {
        IEnumerable<T> Items { get; }
        public int TotalRow { get; }
        public int TotalPage { get; }
    }
}
