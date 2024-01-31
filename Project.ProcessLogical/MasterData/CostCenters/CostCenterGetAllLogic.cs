using Mapster;
using Project.Core.Attributes;
using Project.Core.Models;
using Project.Core.Paging;
using Project.Models.Parameters.CostCenters;
using Project.Models.Responses.CostCenters;
using Project.Repository.Repositories.CostCenters;
using Shared.ORM.Entities;
using System.Linq.Expressions;

namespace Project.ProcessLogical.MasterData.CostCenters
{
    [Scope]
    public class CostCenterGetAllLogic : IProcessLogic<IGetAllCostCenterParameter, IPaging<CostCenterPagingResponse>>
    {
        /// <summary>
        /// Cost center repository
        /// </summary>
        private readonly ICostCenterFakeDataRepository _costCenterRepository;

        public CostCenterGetAllLogic(ICostCenterFakeDataRepository costCenterRepository)
        {
            _costCenterRepository = costCenterRepository;
        }

        public async Task<IPaging<CostCenterPagingResponse>?> ProcessAsync(IGetAllCostCenterParameter param, CancellationToken stoppingToken)
        {
            var costCenters = _costCenterRepository.GetAll(x =>
                (param.Id == null || x.Id == param.Id)
                && (param.CostCenterName == null || x.CostCenterName.Contains(param.CostCenterName)))
                .Skip((param.PageIndex - 1) * param.PageLength).Take(param.PageLength);
            var count = await _costCenterRepository.CountAsync(x =>
                (param.Id == null || x.Id == param.Id)
                && (param.CostCenterName == null || x.CostCenterName.Contains(param.CostCenterName)));
            IPaging<CostCenter> pagings = new Paging<CostCenter>(
                costCenters,
                costCenters.Count(),
                count
                );
            var result = pagings.Adapt<IPaging<CostCenterPagingResponse>>();
            return result;
        }
    }
}
