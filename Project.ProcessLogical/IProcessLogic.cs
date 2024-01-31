namespace Project.ProcessLogical
{
    public interface IProcessLogic<TParam, TResult> where TParam : class
    {
        Task<TResult?> ProcessAsync(TParam param, CancellationToken stoppingToken);
    }
}