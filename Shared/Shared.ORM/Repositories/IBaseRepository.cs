using System.Linq.Expressions;

namespace Shared.ORM.Repositories
{
    public interface IBaseRepository<TModel, TId> where TModel : class
    {
        IQueryable<TModel> GetAll(Expression<Func<TModel, bool>> queryExpression, bool asNoTracking = false);
        Task<TModel?> FindByIdAsync(TId id);
        Task<TModel?> FindFirstOrDefaultAsync(Expression<Func<TModel, bool>> queryExpression);
        Task<int> CountAsync(Expression<Func<TModel, bool>> queryExpression);
        void Update(TModel model);
        void Add(TModel model);
        void AddRange(IEnumerable<TModel> models);
        void UpdateRange(IEnumerable<TModel> models);
        void DeleteRange(IEnumerable<TModel> models);
    }
}
