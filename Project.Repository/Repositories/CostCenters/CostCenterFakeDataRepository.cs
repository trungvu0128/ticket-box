
using Mapster;
using Project.Core.Attributes;
using Shared.ORM.Entities;
using Shared.ORM.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace Project.Repository.Repositories.CostCenters
{
    public interface ICostCenterFakeDataRepository : IBaseRepository<CostCenter, int>
    {
    }

    [Singleton]
    public class CostCenterFakeDataRepository : ICostCenterFakeDataRepository
    {
        private readonly List<CostCenter> _context = Enumerable.Range(0, 1000).Select(s =>
            new CostCenter
            {
                Id = s,
                CostCenterCode = $"code {s}",
                CostCenterName = $"name {s}",
                SapName = $"sap {s}",
                SapDesc = $"sap desc {s}",
                Note = $"note {s}",
                CreateBy = "admin",
                CreateDate = DateTime.Now,
                LocationId = s
            }).ToList();
        public void Add(CostCenter model)
        {
            _context.Add(model);
        }

        public void AddRange(IEnumerable<CostCenter> models)
        {
            _context.AddRange(models);
        }

        public async Task<int> CountAsync(Expression<Func<CostCenter, bool>> queryExpression)
        {
            return await Task.FromResult(_context.Count);
        }

        public void DeleteRange(IEnumerable<CostCenter> models)
        {
            _context.RemoveRange(0, models.Count());
        }

        public async Task<CostCenter?> FindByIdAsync(int id)
        {
            var result = _context.Find(x => x.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<CostCenter?> FindFirstOrDefaultAsync(Expression<Func<CostCenter, bool>> queryExpression)
        {
            var result = _context.FirstOrDefault(queryExpression.Compile());
            return await Task.FromResult(result);
        }

        public IQueryable<CostCenter> GetAll(Expression<Func<CostCenter, bool>> queryExpression, bool asNoTracking = false)
        {
            var result = _context.Where(queryExpression.Compile());
            return result.AsQueryable();
        }

        public void Update(CostCenter model)
        {
            var costCenter = _context.Find(x => x.Id == model.Id);
            model.Adapt(costCenter);
        }

        public void UpdateRange(IEnumerable<CostCenter> models)
        {
            throw new NotImplementedException();
        }
    }
}
