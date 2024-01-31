using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Project.Core.Attributes;

namespace Project.ProcessLogical
{
    public interface IProcessLogicalFactory
    {
        IProcessLogic<TParam, TResult> CreateInstance<TParam, TResult>(Type implementType) where TParam : class;
        IProcessLogic<TParam, TResult> CreateInstance<TParam, TResult>(HttpContext context) where TParam : class;
    }

    [Singleton]
    public class ProcessLogicalFactory : IProcessLogicalFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ProcessLogicalFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IProcessLogic<TParam, TResult> CreateInstance<TParam, TResult>(Type implementType) where TParam : class
        {
            var ctor = implementType.GetConstructors()
            .Where(c => c.IsPublic)
            .OrderByDescending(c => c.GetParameters().Length)
            .FirstOrDefault()
            ?? throw new InvalidOperationException($"No suitable contructor found on type '{implementType}'");

            var injectionServices = ctor.GetParameters()
                .Select(p => _serviceProvider.GetRequiredService(p.ParameterType))
                .ToArray();

            return (IProcessLogic<TParam, TResult>)ctor.Invoke(injectionServices);
        }

        public IProcessLogic<TParam, TResult> CreateInstance<TParam, TResult>(HttpContext context) where TParam : class
        {
            IProcessLogic<TParam, TResult> result = context.RequestServices.GetRequiredService<IProcessLogic<TParam, TResult>>();
            return result;
        }
    }
}
