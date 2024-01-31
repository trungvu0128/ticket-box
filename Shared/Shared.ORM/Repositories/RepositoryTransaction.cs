using Microsoft.EntityFrameworkCore.Storage;
using Shared.ORM.Entities;

namespace Shared.ORM.Repositories
{
    public class RepositoryTransaction : RepositoryContext, IRepositoryTransaction
    {
        public RepositoryTransaction(DatabaseContext context) : base(context)
        {
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task SavesChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
