using Project.Core.Attributes;
using Shared.ORM.Entities;
using Shared.ORM.Repositories;

namespace Project.Repository.Repositories.CostCenters
{
    [Scope]
    public class CostCenterRepository : BaseRepository<CostCenter, int>, ICostCenterRepository
    {
        public CostCenterRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
