using System.Text.RegularExpressions;
using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;

namespace LoginCodeFirst.Validators
{
    public class IndexValidator : AbstractValidator<IndexViewModel>
    {
        public IndexValidator(ResourcesServices<UserResources> localizer,ResourcesServices<CommonResources> commonlocalizer,IUserServices userServices)
        {
            RuleFor(x => x.Email).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.Password)
                .NotNull().WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.FullName)
                .NotNull().WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.Phone)
                .NotNull().WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotEmpty"));
            RuleFor(x => x.IsActive).NotNull();
            
            RuleFor(x => x.Email).Must((reg,c) => !userServices.IsExistedName(reg.Email,reg.UserId))
                .WithMessage((reg,c) => string.Format(commonlocalizer.GetLocalizedHtmlString("msg_ThisEmailAlreadyExists"),c));
            
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_AValidEmail"));
             RuleFor(x => x.Password)
                .MinimumLength(8).WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_8Characters"));
            RuleFor(x => x.Password)
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$")
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_LettersAndNumbers"));
           
            
        }
    }
}