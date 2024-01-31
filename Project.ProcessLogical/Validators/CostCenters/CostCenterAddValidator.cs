using FluentValidation;
using Project.Models.Parameters.CostCenters;
using Project.Repository.Commands.Positions;

namespace Project.ProcessLogical.Validators.CostCenters
{
    public class CostCenterAddValidator : AbstractValidator<IAddCostCenterParameter>
    {
        public CostCenterAddValidator(IPositionCommand command)
        {
            Include(new CostCenterValidator(command));
        }
    }
}