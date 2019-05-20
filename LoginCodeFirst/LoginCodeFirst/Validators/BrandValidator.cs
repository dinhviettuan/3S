using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Brand;

namespace LoginCodeFirst.Validators.BrandValidator
{
    public class BrandValidator : AbstractValidator<BrandViewModel>
    {
        public BrandValidator(ResourcesServices<BrandResources> localizer,IBrandServices brandService)
        {              
            RuleFor(x => x.BrandName).Must((reg,c) => !brandService.IsExistedName(reg.BrandName,reg.BrandId))
                    .WithMessage(localizer.GetLocalizedHtmlString("lbl_ThisBrandNameAlreadyExists"));
            RuleFor(x => x.BrandName).NotNull()
                    .WithMessage(localizer.GetLocalizedHtmlString("lbl_BrandNameNotBeEmpty"));
            RuleFor(x => x.BrandName).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_StartWithLetters"));
        }
    }
}