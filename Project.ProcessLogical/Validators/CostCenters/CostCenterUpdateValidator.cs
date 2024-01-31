using FluentValidation;
using Project.Models.Constants;
using Project.Models.Parameters.CostCenters;
using Project.Repository.Commands.CostCenters;
using Project.Repository.Commands.Positions;

namespace Project.ProcessLogical.Validators.CostCenters
{
    public class CostCenterUpdateValidator : AbstractValidator<IUpdateCostCenterParameter>
    {
        public CostCenterUpdateValidator(IPositionCommand positionCommand, ICostCenterCommand costCenterCommand)
        {
            RuleFor(x => x.Id)
                .Must(costCenterCommand.IsCodeCenterExist).WithMessage(ResponseMessage.ID_NOT_FOUND);
            Include(new CostCenterValidator(positionCommand));
        }
    }
}
