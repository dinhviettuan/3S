//using System.Linq;
//using FluentValidation;
//using LoginCodeFirst.Models;
//using LoginCodeFirst.Services;
//using LoginCodeFirst.ViewModels.User;
//using Microsoft.Extensions.Localization;
//
//namespace LoginCodeFirst.Validator
//{
//    public class AddValidator : AbstractValidator<AddViewModel>
//    {
//        public AddValidator(IUserServices userServices, IStringLocalizer<AddValidator> localizer)
//        {
//            var users = userServices.Users();
//            foreach (var user in users)
//            {
//                RuleFor(x => x.Email).NotEqual(users.Email).WithMessage(localizer["This Email already exists."]);
//            }
//
//            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email not be empty"]);
//            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["must start with a letter"]);
//            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["The email must include letters and numbers"]);
//            RuleFor(x => x.Password).NotNull().WithMessage(localizer["Password not be empty"]);
//            RuleFor(x => x.Password).MinimumLength(5).WithMessage(localizer["not less than 6 characters"]);
//            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
//            RuleFor(x => x.FullName).NotNull().WithMessage(localizer["Fullname not be empty"]);
//            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
//            RuleFor(x => x.IsActive).NotNull();
//            RuleFor(x => x.Password).Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$");
//        }
//    }
//}