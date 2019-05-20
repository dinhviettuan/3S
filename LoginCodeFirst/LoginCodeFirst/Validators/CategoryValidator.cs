using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Category;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.CategoryValidator
{
    public class CategoryValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator(ResourcesServices<CategoryResources> localizer, ICategoryServices categoryServices)
        { 
                
            RuleFor(x => x.CategoryName).Must((Reg,c) => !categoryServices.IsExistedName(Reg.CategoryName,Reg.CategoryId))
                    .WithMessage(localizer.GetLocalizedHtmlString("lbl_ThisCategoryNameAlreadyExists"));
            RuleFor(x => x.CategoryName).NotNull()
                    .WithMessage(localizer.GetLocalizedHtmlString("lbl_CategoryNameNotBeEmpty"));
            RuleFor(x => x.CategoryName).NotNull()
                    .WithMessage(localizer.GetLocalizedHtmlString("lbl_StartWithLetters"));
        }
    }
}
