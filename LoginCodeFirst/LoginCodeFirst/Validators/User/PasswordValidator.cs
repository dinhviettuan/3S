using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;

namespace LoginCodeFirst.Validators.User
{
    public class PasswordValidator : AbstractValidator<PasswordViewModel>
    {
        public PasswordValidator(ResourcesServices<UserResources> localizer,ResourcesServices<CommonResources> commonlocalizer,IUserServices userServices)
        {
            RuleFor(x => x.NewPassword).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.ConfirmPassword).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty")); 
            
            RuleFor(x => x.NewPassword).Must((reg,c) => !userServices.IsExistedPassword(reg.NewPassword,reg.Id))
                .WithMessage((reg,c) => string.Format(localizer.GetLocalizedHtmlString("msg_AlreadyExistsPassword"),c)); 
            
            
            RuleFor(x => x.NewPassword).MinimumLength(8)
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_8Characters"));
            RuleFor(x => x.NewPassword).Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").
                WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_LettersAndNumbers"));
            RuleFor(x => x.ConfirmPassword).Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").
                WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_LettersAndNumbers"));
            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword)
                .WithMessage(localizer.GetLocalizedHtmlString("msg_ConfirmPasswordMustBeEqualNewPassword"));
        }
    }
}