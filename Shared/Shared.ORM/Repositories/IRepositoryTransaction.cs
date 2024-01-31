using Microsoft.EntityFrameworkCore.Storage;

namespace Shared.ORM.Repositories
{
    public interface IRepositoryTransaction
    {
        Task SavesChangeAsync();
        IDbContextTransaction BeginTransaction();
    }
}
