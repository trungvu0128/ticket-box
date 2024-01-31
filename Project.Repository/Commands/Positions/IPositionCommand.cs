using Shared.ORM.Repositories;

namespace Project.Repository.Commands.Positions
{
    public interface IPositionCommand : IBaseQueryCommand
    {
        bool IsPositionExist(int? positionId);
    }
}
