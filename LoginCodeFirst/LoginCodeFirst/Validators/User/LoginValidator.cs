using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels;
using LoginCodeFirst.ViewModels.User;
using Microsoft.Extensions.Localization;
namespace LoginCodeFirst.Validator
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator(ResourcesServices<CommonResources> commonlocalizer)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_WithALetter"));
            RuleFor(x => x.Password).NotNull().WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.Password).MinimumLength(5).WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_8Characters"));
        }
    }
}