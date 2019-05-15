using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Brand;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.BrandValidator
{
    public class BrandValidator : AbstractValidator<BrandViewModel>
    {
        public BrandValidator(IStringLocalizer localizer,IBrandServices brandService)
        {              
            RuleFor(x => x.BrandName).Must((reg,c) => !brandService.IsExistedName(reg.BrandName,reg.BrandId))
                    .WithMessage(localizer["This BrandName already exists."]);
            RuleFor(x => x.BrandName).NotNull()
                    .WithMessage(localizer["BrandName not be empty"]);
            RuleFor(x => x.BrandName).NotNull()
                .WithMessage(localizer["Start with letters"]);
        }
    }
}