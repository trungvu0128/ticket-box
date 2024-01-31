using Mapster;
using Project.Core.Attributes;
using Project.Models.Constants;
using Project.Models.Parameters.CostCenters;
using Project.Repository.Commands.CostCenters;
using Project.Repository.Repositories.CostCenters;
using Shared.ORM.Entities;

namespace Project.ProcessLogical.MasterData.CostCenters
{
    [Scope]
    public class CostCenterUpdateLogic : IProcessLogic<IUpdateCostCenterParameter, bool>
    {
        /// <summary>
        /// Cost center Update command
        /// </summary>
        private readonly ICostCenterFakeDataRepository _costCenterRepository;

        public CostCenterUpdateLogic(ICostCenterFakeDataRepository costCenterRepository)
        {
            _costCenterRepository = costCenterRepository;
        }

        public async Task<bool> ProcessAsync(IUpdateCostCenterParameter param, CancellationToken stoppingToken)
        {
            param.UpdateBy = "Admin";
            var costCenter = param.Adapt<CostCenter>();
            _costCenterRepository.Update(costCenter);
            return await Task.FromResult(true);
        }
    }
}
