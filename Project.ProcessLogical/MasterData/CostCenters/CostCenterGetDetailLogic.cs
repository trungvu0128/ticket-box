using Mapster;
using Microsoft.EntityFrameworkCore;
using Project.Core.Attributes;
using Project.Core.Models.Requests;
using Project.Models.Constants;
using Project.Models.Responses;
using Project.Repository.Commands.CostCenters;
using Project.Repository.Repositories.CostCenters;

namespace Project.ProcessLogical.MasterData.CostCenters
{
    [Scope]
    public class CostCenterGetDetailLogic : IProcessLogic<GetByIdRequest<int>, CostCenterResponse>
    {
        /// <summary>
        /// Cost center GetDetail command
        /// </summary>
        private readonly ICostCenterFakeDataRepository _costCenterRepository;

        public CostCenterGetDetailLogic(ICostCenterFakeDataRepository costCenterGetDetailCommand)
        {
            _costCenterRepository = costCenterGetDetailCommand;
        }

        public async Task<CostCenterResponse?> ProcessAsync(GetByIdRequest<int> param, CancellationToken stoppingToken)
        {
            var costCenter = await _costCenterRepository.FindByIdAsync(param.Id);
            return costCenter.Adapt<CostCenterResponse>();
        }
    }
}
