//using System.Security.Cryptography.X509Certificates;
//using FluentValidation;
//using LoginCodeFirst.Models;
//using LoginCodeFirst.ModelView;
//using LoginCodeFirst.Services;
//using Microsoft.Extensions.Localization;
//
//namespace LoginCodeFirst.EditStoreValidator
//{
//    public class EditStoreValidator : AbstractValidator<StoreEditViewModel>
//    {
//        public EditStoreValidator(IStoreServices storeServices, IStringLocalizer<EditStoreValidator> localizer)
//        {
//            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email not be empty"]);
//            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["must start with a letter"]);
//            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["The email must include letters and numbers"]);
//            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
//            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer["StoreName not be empty"]);
//
//        }
//    }
//}