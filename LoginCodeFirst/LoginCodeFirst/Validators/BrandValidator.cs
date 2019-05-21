using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Brand;

namespace LoginCodeFirst.Validators.BrandValidator
{
    public class BrandValidator : AbstractValidator<BrandViewModel>
    {
        public BrandValidator(ResourcesServices<CommonResources> commonlocalizer,IBrandServices brandService)
        {         
            RuleFor(x => x.BrandName).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            
            RuleFor(x => x.BrandName).Must((reg,c) => !brandService.IsExistedName(reg.BrandName,reg.BrandId))
                    .WithMessage((reg,c) => string.Format(commonlocalizer.GetLocalizedHtmlString("msg_AlreadyExists"),c));       
        }
    }
}