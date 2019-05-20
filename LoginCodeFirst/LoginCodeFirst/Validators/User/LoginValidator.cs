using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.Extensions.Localization;
namespace LoginCodeFirst.Validator
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator(ResourcesServices<LoginResources> localizer,IUserServices userServices)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(localizer.GetLocalizedHtmlString("lbl_EmailNotBeEmpty"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer.GetLocalizedHtmlString("lbl_MustStartWithALetter"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer.GetLocalizedHtmlString("lbl_EmailIncludingLettersAndNumbers"));
            RuleFor(x => x.Password).NotNull().WithMessage(localizer.GetLocalizedHtmlString("lbl_PasswordNotBeEmpty"));
            RuleFor(x => x.Password).MinimumLength(5).WithMessage(localizer.GetLocalizedHtmlString("lbl_NotLessThan5Characters"));
        }
    }
}