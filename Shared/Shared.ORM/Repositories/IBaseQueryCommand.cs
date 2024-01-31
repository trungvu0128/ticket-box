namespace Shared.ORM.Repositories
{
    public interface IBaseQueryCommand
    {
        IQueryable<TResult> ExecuteProc<TTParameter, TResult>(string procName, TTParameter parameters);
        IQueryable<TResult> ExecuteProc<TResult>(string procName, Dictionary<string, object> parameters);
        Task<int> ExecuteNonQueryProcAsync<TTParameter>(string procName, Dictionary<string, object> parameters);
        Task<int> ExecuteNonQueryProcAsync<TTParameter>(string procName, TTParameter parameters);
        IQueryable<TResult> ExecuteProc<TResult>(string procName);
        Task<int> ExecuteNonQueryProcAsync<TResult>(string procName);
    }
}
