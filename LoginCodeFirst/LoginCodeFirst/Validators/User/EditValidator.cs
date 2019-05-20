using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;

namespace LoginCodeFirst.Validators.User
{
    public class IndexValidator : AbstractValidator<EditViewModel>
    {
        public IndexValidator(ResourcesServices<CommonResources> commonlocalizer,IUserServices userServices)
        {
            RuleFor(x => x.Email).Must((reg,c) => !userServices.IsExistedName(reg.Email,reg.UserId))
                .WithMessage((reg,c) => string.Format(commonlocalizer.GetLocalizedHtmlString("msg_AlreadyExists"),c));
            
            RuleFor(x => x.Email).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_AValidEmail"));            
            RuleFor(x => x.FullName).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.Phone).NotNull()
                .WithMessage(commonlocalizer.GetLocalizedHtmlString("msg_NotBeEmpty"));
            RuleFor(x => x.IsActive).NotNull();
        }

    }
}