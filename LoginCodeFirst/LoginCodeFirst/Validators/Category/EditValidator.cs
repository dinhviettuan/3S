//using FluentValidation;
//using LoginCodeFirst.Models;
//using LoginCodeFirst.Services;
//using LoginCodeFirst.ViewModel.Category;
//using Microsoft.Extensions.Localization;
//
//namespace LoginCodeFirst.CategoryValidator
//{
//    public class EditValidator : AbstractValidator<EditValidator>
//    {
//        public EditValidator(ICategoryServices categoryServices,IStringLocalizer<EditValidator> localizer)
//        {
//            RuleFor(x => x.).NotNull().WithMessage(localizer["CategoryName not be empty"]);
//            RuleFor(x => x.CategoryName).NotNull().WithMessage(localizer["Start with letters"]);
//        }
//    }
//}