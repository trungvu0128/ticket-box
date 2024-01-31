using Microsoft.EntityFrameworkCore;
using Shared.ORM.Entities;
using System.Linq.Expressions;

namespace Shared.ORM.Repositories
{
    public class BaseRepository<TModel, TId> : RepositoryContext, IBaseRepository<TModel, TId> where TModel : class
    {
        public BaseRepository(DatabaseContext context) : base(context)
        {
        }

        public void Add(TModel model)
        {
            _context.Set<TModel>().Add(model);
        }

        public void AddRange(IEnumerable<TModel> models)
        {
            _context.Set<TModel>().AddRange(models);
        }

        public async Task<int> CountAsync(Expression<Func<TModel, bool>> queryExpression)
        {
            return await _context.Set<TModel>().CountAsync(queryExpression);
        }

        public async Task<TModel?> FindByIdAsync(TId id)
        {
            return await _context.Set<TModel>().FindAsync(id);
        }

        public async Task<TModel?> FindFirstOrDefaultAsync(Expression<Func<TModel, bool>> queryExpression)
        {
            return await _context.Set<TModel>().FirstOrDefaultAsync(queryExpression);
        }

        public IQueryable<TModel> GetAll(Expression<Func<TModel, bool>> queryExpression, bool asNoTracking = false)
        {
            IQueryable<TModel> result = _context.Set<TModel>().Where(queryExpression);
            if (asNoTracking)
            {
                return result.AsNoTracking();
            }
            return result;
        }

        public void Update(TModel model)
        {
            _context.Set<TModel>().Update(model);
        }

        public void UpdateRange(IEnumerable<TModel> models)
        {
            _context.Set<TModel>().UpdateRange(models);
        }

        public void DeleteRange(IEnumerable<TModel> models)
        {
            _context.Set<TModel>().RemoveRange(models);
        }
    }
}
