using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.Extensions.Localization;
namespace LoginCodeFirst.Validator
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator(IUserServices userServices,IStringLocalizer<LoginValidator> localizer)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email not be empty"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["must start with a letter"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["Email including letters and numbers"]);
            RuleFor(x => x.Password).NotNull().WithMessage(localizer["Password not be empty"]);
            RuleFor(x => x.Password).MinimumLength(5).WithMessage(localizer["not less than 5 characters"]);
        }
    }
}