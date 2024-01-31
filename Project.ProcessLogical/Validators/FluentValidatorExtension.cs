using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Project.ProcessLogical.Validators.CostCenters;
using FluentValidation.AspNetCore;

namespace Project.ProcessLogical.Validators
{
    public static class FluentValidatorExtension
    {
        public static void UseValidator(this IServiceCollection services)
        {
            ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop; ;
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CostCenterAddValidator>();
        }
    }
}
