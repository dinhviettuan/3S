using FluentValidation;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validator
{
    public class EditValidator: AbstractValidator<IndexViewModel>
    {
        public EditValidator(IUserServices userServices, IStringLocalizer<EditValidator> localizer)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email not be empty"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["must start with a letter"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["The email must include letters and numbers"]); 
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
            RuleFor(x => x.FullName).NotNull().WithMessage(localizer["Fullname not be empty"]);
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
            RuleFor(x => x.IsActive).NotNull();
        }
       
    }
}