using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Category;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.CategoryValidator
{
    public class CategoryValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator(ResourcesServices<CommonResources> commonlocalizer, ICategoryServices categoryServices)
        { 
                
            RuleFor(x => x.CategoryName).Must((Reg,c) => !categoryServices.IsExistedName(Reg.CategoryName,Reg.CategoryId))
                    .WithMessage((reg,c) => string.Format(commonlocalizer.GetLocalizedHtmlString("msg_AlreadyExists"),c));
            
            RuleFor(x => x.CategoryName).NotNull()
                    .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
        }
    }
}
