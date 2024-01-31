using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared.ORM.Entities;
using System.Reflection;
using System.Text;

namespace Shared.ORM.Repositories
{
    public class BaseQueryCommand : RepositoryContext, IBaseQueryCommand
    {
        public BaseQueryCommand(DatabaseContext context) : base(context)
        {
        }
        public IQueryable<TResult> ExecuteProc<TTParameter, TResult>(string procName, TTParameter parameters)
        {
            ArgumentNullException.ThrowIfNull(parameters, "parameters");
            List<SqlParameter> sqlParameters = new();
            var builder = new StringBuilder($"Execute {procName} ");
            var types = parameters.GetType().GetProperties();
            for (int i = 0; i < types.Length; i++)
            {
                PropertyInfo v = types[i];
                if (i < types.Length - 1)
                {
                    builder.Append($"@{v.Name}=@{v.Name}, ");
                }
                else
                {
                    builder.Append($"@{v.Name}=@{v.Name}");
                }
                var sqlParameter = new SqlParameter($"@{v.Name}", v.GetValue(parameters) ?? DBNull.Value);
                sqlParameters.Add(sqlParameter);
            }
            var result = _context.Database.SqlQueryRaw<TResult>(builder.ToString(), sqlParameters.ToArray());
            return result;
        }

        public IQueryable<TResult> ExecuteProc<TResult>(string procName)
        {
            var builder = new StringBuilder($"Execute {procName} ");
            var result = _context.Database.SqlQueryRaw<TResult>(builder.ToString());
            return result;
        }

        public async Task<int> ExecuteNonQueryProcAsync<TResult>(string procName)
        {
            var builder = new StringBuilder($"Execute {procName} ");
            var result = await _context.Database.ExecuteSqlRawAsync(builder.ToString());
            return result;
        }

        public async Task<int> ExecuteNonQueryProcAsync<TTParameter>(string procName, TTParameter parameters)
        {
            ArgumentNullException.ThrowIfNull(parameters, "parameters");
            List<SqlParameter> sqlParameters = new();
            var builder = new StringBuilder($"Execute {procName} ");
            PropertyInfo[] properties = parameters.GetType().GetProperties(); ;
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo v = properties[i];
                if (i < properties.Length - 1)
                {
                    builder.Append($"@{v.Name}=@{v.Name}, ");
                }
                else
                {
                    builder.Append($"@{v.Name}=@{v.Name}");
                }
                var sqlParameter = new SqlParameter($"@{v.Name}", v.GetValue(parameters) ?? DBNull.Value);
                sqlParameters.Add(sqlParameter);
            }
            return await _context.Database.ExecuteSqlRawAsync(builder.ToString(), sqlParameters.ToArray());
        }

        public async Task<int> ExecuteNonQueryProcAsync<TTParameter>(string procName, Dictionary<string, object> parameters)
        {
            ArgumentNullException.ThrowIfNull(parameters, "parameters");
            List<SqlParameter> sqlParameters = new();
            var builder = new StringBuilder($"Execute {procName} ");
            for (int i = 0; i < parameters.Count; i++)
            {
                var item = parameters.ElementAt(i);
                if (i < parameters.Count - 1)
                {
                    builder.Append($"@{item.Key}=@{item.Key}, ");
                }
                else
                {
                    builder.Append($"@{item.Key}=@{item.Key}");
                }
                var sqlParameter = new SqlParameter(item.Key, item.Value ?? DBNull.Value);
                sqlParameters.Add(sqlParameter);
            }
            return await _context.Database.ExecuteSqlRawAsync(builder.ToString(), sqlParameters.ToArray());
        }

        public IQueryable<TResult> ExecuteProc<TResult>(string procName, Dictionary<string, object> parameters)
        {
            ArgumentNullException.ThrowIfNull(parameters, "parameters");
            List<SqlParameter> sqlParameters = new();
            var builder = new StringBuilder($"Execute {procName} ");
            for (int i = 0; i < parameters.Count; i++)
            {
                var item = parameters.ElementAt(i);
                if (i < parameters.Count - 1)
                {
                    builder.Append($"@{item.Key}=@{item.Key}, ");
                }
                else
                {
                    builder.Append($"@{item.Key}=@{item.Key}");
                }
                var sqlParameter = new SqlParameter(item.Key, item.Value ?? DBNull.Value);
                sqlParameters.Add(sqlParameter);
            }
            var result = _context.Database.SqlQueryRaw<TResult>(builder.ToString(), sqlParameters.ToArray());
            return result;
        }
    }
}
