using Mapster;
using Project.Core.Attributes;
using Project.Core.Extensions;
using Project.Models.Parameters.CostCenters;
using Project.Repository.Repositories.CostCenters;
using Shared.ORM.Entities;
using Shared.ORM.Repositories;

namespace Project.ProcessLogical.MasterData.CostCenters
{
    [Scope]
    public class CostCenterAddLogic : IProcessLogic<IAddCostCenterParameter, bool>
    {
        /// <summary>
        /// Cost center add repository
        /// </summary>
        private readonly ICostCenterFakeDataRepository _costCenterRepository;

        private readonly IRepositoryTransaction _transaction;

        public CostCenterAddLogic(ICostCenterFakeDataRepository costCenterRepository, IRepositoryTransaction transaction)
        {
            _costCenterRepository = costCenterRepository;
            _transaction = transaction;
        }

        public async Task<bool> ProcessAsync(IAddCostCenterParameter param, CancellationToken stoppingToken)
        {
            var costCenter = param.Adapt<CostCenter>();
            costCenter.SetEntityCreated("admin");
            _costCenterRepository.Add(costCenter);
            await _transaction.SavesChangeAsync();
            return true;
        }
    }
}
