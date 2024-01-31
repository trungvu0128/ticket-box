using Microsoft.AspNetCore.Mvc;
using Project.Core.Controllers;
using Project.Core.Models.Requests;
using Project.Core.Paging;
using Project.Models.Parameters;
using Project.Models.Parameters.CostCenters;
using Project.Models.Requests.CostCenters;
using Project.Models.Responses;
using Project.Models.Responses.CostCenters;
using Project.ProcessLogical;
using Shared.Tracking;

namespace Project.Controllers.MasterData
{
    [ApiController]
    [Route("cost-center")]
    public class CostCenterController : BaseController
    {
        private readonly IProcessLogicalFactory _factory;

        /// <summary>
        /// Initialize new instance of controller
        /// </summary>
        /// <param name="trackingLog"></param>
        /// <param name="factory"></param>
        public CostCenterController(
            ITrackingLog trackingLog,
            IProcessLogicalFactory factory) : base(trackingLog)
        {
            _factory = factory;
        }

        /// <summary>
        /// Add cost center route
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCostCenter([FromBody] AddCostCenterRequest request, CancellationToken cancellationToken)
        {
            IAddCostCenterParameter parameter = request.MapParameter<IAddCostCenterParameter>();
            bool result = await _factory
                .CreateInstance<IAddCostCenterParameter, bool>(HttpContext)
                .ProcessAsync(parameter, cancellationToken);
            return ResponseOk(result);
        }

        /// <summary>
        /// Update cost center route
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCostCenter(int id, [FromBody] UpdateCostCenterRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;
            IUpdateCostCenterParameter parameter = request.MapParameter<IUpdateCostCenterParameter>();
            bool result = await _factory
                .CreateInstance<IUpdateCostCenterParameter, bool>(HttpContext)
                .ProcessAsync(parameter, cancellationToken);
            return ResponseOk(result);
        }

        /// <summary>
        /// Get paging cost center route
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCostCenter([FromQuery] GetAllCostCenterRequest request, CancellationToken cancellationToken)
        {
            IGetAllCostCenterParameter parameter = request.MapParameter<IGetAllCostCenterParameter>();
            IPaging<CostCenterPagingResponse>? result = await _factory
                .CreateInstance<IGetAllCostCenterParameter, IPaging<CostCenterPagingResponse>>(HttpContext)
                .ProcessAsync(parameter, cancellationToken);
            return ResponseOk(result);
        }

        /// <summary>
        /// Get paging cost center route
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailCostCenter([FromRoute] int id, CancellationToken cancellationToken)
        {
            GetByIdRequest<int> parameter = new() { Id = id };
            var result = await _factory
                .CreateInstance<GetByIdRequest<int>, CostCenterResponse>(HttpContext)
                .ProcessAsync(parameter, cancellationToken);
            return ResponseOk(result);
        }
    }
}
