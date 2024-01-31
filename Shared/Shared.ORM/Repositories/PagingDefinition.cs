using Microsoft.EntityFrameworkCore;
using Shared.ORM.Models;

namespace Shared.ORM.Repositories
{
    public static class PagingDefinition
    {
        public static async Task<Paging<TModel>> PagingAsync<TModel>(this IQueryable<TModel> models, int pageNumber, int pageSize)
        {
            var count = await models.CountAsync();
            var pagingResult = await models.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var totalPage = (int)Math.Ceiling(count / (double)pageSize);
            return new Paging<TModel>(pagingResult, count, totalPage);
        }
    }
}
