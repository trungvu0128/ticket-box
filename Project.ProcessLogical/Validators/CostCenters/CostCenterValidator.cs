using FluentValidation;
using Project.Models.Constants;
using Project.Models.Parameters.CostCenters;
using Project.Repository.Commands.Positions;

namespace Project.ProcessLogical.Validators.CostCenters
{
    public class CostCenterValidator : AbstractValidator<ICostCenterParameter>
    {
        public CostCenterValidator(IPositionCommand positionCommand)
        {
            RuleFor(x => x.CostCenterName)
                .Must(costCeterName => !string.IsNullOrEmpty(costCeterName)).WithMessage(ResponseMessage.COST_CENTER_NAME_REQUIRED);
            RuleFor(x => x.Note)
                .Must(note => !string.IsNullOrEmpty(note)).WithMessage(ResponseMessage.NOTE_REQUIRED);
            RuleFor(x => x.SapDesc)
                .Must(sapDesc => !string.IsNullOrEmpty(sapDesc)).WithMessage(ResponseMessage.SAP_DESC_REQUIRED);
            RuleFor(x => x.SapName)
                .Must(sapName => !string.IsNullOrEmpty(sapName)).WithMessage(ResponseMessage.SAP_NAME_REQUIRED);
            RuleFor(x => x.PositionId)
                .Must(positionCommand.IsPositionExist).WithMessage(ResponseMessage.POSITION_ID_NOT_FOUND);
        }
    }
}
