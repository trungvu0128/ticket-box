using Shared.ORM.Repositories;

namespace Project.Repository.Commands.CostCenters
{
    public interface ICostCenterCommand : IBaseQueryCommand
    {
        bool IsCodeCenterExist(int arg);
    }
}
