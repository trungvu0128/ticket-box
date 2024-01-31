using Shared.ORM.Entities;

namespace Shared.ORM.Repositories
{
    public class RepositoryContext
    {
        protected readonly DatabaseContext _context;
        public RepositoryContext(DatabaseContext context)
        {
            _context = context;
        }
    }
}
