using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.Category;

namespace LoginCodeFirst.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator(ResourcesServices<CommonResources> commonlocalizer, ICategoryServices categoryServices)
        {          
            RuleFor(x => x.CategoryName).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            
            RuleFor(x => x.CategoryName).Must((reg,c) => !categoryServices.IsExistedName(reg.CategoryName,reg.CategoryId))
                    .WithMessage((reg,c) => string.Format(commonlocalizer.GetLocalizedHtmlString("msg_AlreadyExists"),c));    
        }
    }
}
