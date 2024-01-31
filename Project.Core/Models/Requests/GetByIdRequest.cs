namespace Project.Core.Models.Requests
{
    public record GetByIdRequest<T>
    {
        public virtual required T Id { get; set; }
    }
}
