using Project.Core.Attributes;
using Project.Core.Models.Requests;
using Project.Models.Constants;
using Project.Models.Responses;
using Shared.ORM.Entities;
using Shared.ORM.Repositories;

namespace Project.Repository.Commands.CostCenters
{
    /// <summary>
    /// Cost center command
    /// </summary>
    [Scope]
    public class CostCenterCommand : BaseQueryCommand, ICostCenterCommand
    {
        /// <summary>
        /// Initialize a new instance of command
        /// </summary>
        /// <param name="context"></param>
        public CostCenterCommand(DatabaseContext context) : base(context)
        {
        }

        public bool IsCodeCenterExist(int arg)
        {
            GetByIdRequest<int> param = new() { Id = arg };
            var query = ExecuteProc<GetByIdRequest<int>, CostCenterResponse>(procName: ProcName.GetDetailCostCenter, param);
            return query.ToList().Count > 0;
        }
    }
}
