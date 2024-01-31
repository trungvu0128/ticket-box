using Project.Core.Attributes;
using Project.Core.Models.Requests;
using Project.Models.Constants;
using Project.Models.Responses.Positions;
using Project.Repository.Commands.CostCenters;
using Shared.ORM.Entities;
using Shared.ORM.Repositories;

namespace Project.Repository.Commands.Positions
{
    [Scope]
    public class PositionCommand : BaseQueryCommand, IPositionCommand
    {
        public PositionCommand(DatabaseContext context) : base(context)
        {
        }

        public bool IsCodeCenterExist(int arg)
        {
            throw new NotImplementedException();
        }

        public bool IsPositionExist(int? positionId)
        {
            if (positionId == null)
            {
                return true;
            }
            GetByIdRequest<int?> param = new() { Id = positionId };
            var query = ExecuteProc<GetByIdRequest<int?>, PositionResponse>(procName: ProcName.GetDetailPosition, param);
            return query.ToList().Count > 0;
        }
    }
}
