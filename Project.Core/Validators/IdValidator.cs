using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Project.Core.Constants;
using Project.Core.Models.Requests;
using Shared.ORM.Repositories;

namespace Project.Core.Validators
{
    public class IdValidator<T, TId> : AbstractValidator<GetByIdRequest<TId>>
        where T : class
    {
        public IdValidator(IBaseRepository<T, TId> repository, string errorMessage)
        {

            RuleFor(x => x.Id)
                .Custom((id, context) =>
                {
                    T? entity = repository.GetAll(x => EF.Property<TId>(x, FieldConstant.IDFIELD)!.Equals(id)).FirstOrDefault();
                    bool isExist = true;
                    if (entity == null)
                    {
                        isExist = false;
                    }
                    else
                    {
                        var deletedProperty = entity.GetType().GetProperty(FieldConstant.DELETEFIELD)?.GetValue(entity);
                        if (deletedProperty != null && deletedProperty is bool deleted && deleted)
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
