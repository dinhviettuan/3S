//using FluentValidation;
//using LoginCodeFirst.Models;
//using LoginCodeFirst.ViewModel.Category;
//using Microsoft.Extensions.Localization;
//
//namespace LoginCodeFirst.CategoryValidator
//{
//    public class AddCategoryViewModel : AbstractValidator<AddCategoryViewModel>
//    {
//        public AddCategoryViewModel(CodeDataContext dataContext, IStringLocalizer<AddCategoryViewModel> localizer)
//        {
//            RuleFor(x => x.).NotNull().WithMessage(localizer["CategoryName not be empty"]);
//            RuleFor(x => x.).NotNull().WithMessage(localizer["Start with letters"]);
//        }
//    }
//}