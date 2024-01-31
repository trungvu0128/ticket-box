using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Project.Core.Constants;
using Project.Core.Models.Requests;
using Shared.ORM.Repositories;

namespace Project.Core.Validators
{

    public class IdListValidator<T, TId> : AbstractValidator<GetByListIdRequest<TId>>
        where T : class
    {
        public IdListValidator(IBaseRepository<T, TId> repository, string errorMessage)
        {
            RuleFor(x => x.Ids)
                .NotEmpty().WithMessage(BaseResponseMessage.ID_NOT_FOUND)
                .Custom((ids, context) =>
                {
                    List<T> entities = repository.GetAll(x => ids.Contains(EF.Property<TId>(x, FieldConstant.IDFIELD))).ToList();
                    bool isExist = true;
                    if (entities.Count == 0)
                    {
                        isExist = false;
                    }
                    else
                    {
                        var deletedProperty = typeof(T).GetProperty(FieldConstant.DELETEFIELD);
                        if (deletedProperty != null && entities.Any(y => EF.Property<bool>(y, FieldConstant.DELETEFIELD)))
                        {
                            isExist = false;
                        }
                    }
                    if (!isExist)
                    {
                        context.AddFailure("Id", errorMessage);
                    }
                });
        }
    }
}
