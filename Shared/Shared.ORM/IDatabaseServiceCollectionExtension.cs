using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.ORM.Entities;

namespace Shared.ORM
{
    public static class IDatabaseServiceCollectionExtension
    {
        public static void UseSQLServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(connectionString));
        }
        public static void UsePostPgresSQL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DatabaseContext>(x => x.UseNpgsql(connectionString));
        }
    }
}
