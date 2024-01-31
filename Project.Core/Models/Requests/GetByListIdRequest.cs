namespace Project.Core.Models.Requests
{
    public record GetByListIdRequest<T>
    {
        public required virtual List<T> Ids { get; set; }
    }
}
