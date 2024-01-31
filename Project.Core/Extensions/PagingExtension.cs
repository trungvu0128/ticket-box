using Microsoft.EntityFrameworkCore;
using Project.Core.Models.Responses;
using Project.Core.Paging;

namespace Project.Core.Models
{
    public static class PagingExtension
    {
        public static async Task<IPaging<T>> PagingAsync<T>(this IQueryable<T> entities, int pageNumber, int pageSize)
        {
            int count = await entities.CountAsync();
            IEnumerable<T> items = entities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var totalPage = (int)Math.Ceiling(count / (double)pageSize);
            return new Paging.Paging<T>(items, count, totalPage);
        }


        public static async Task<IPaging<T>> PagingProcAsync<T>(this IQueryable<T> entities, int pageSize) where T : BasePagingResponse
        {
            var records = await entities.ToListAsync();
            int count = records.Select(s => s.TotalRow ?? 0).FirstOrDefault();
            var totalPage = (int)Math.Ceiling(count / (double)pageSize);
            return new Paging.Paging<T>(entities, count, totalPage);
        }
    }
}
