using FluentValidation;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;

namespace LoginCodeFirst.Validators.User
{
    public class IndexValidator : AbstractValidator<EditViewModel>
    {
        public IndexValidator(ResourcesServices<UserResources> localizer,IUserServices userServices)
        {
            RuleFor(x => x.Email).Must((reg,c) => !userServices.IsExistedName(reg.Email,reg.UserId))
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_ThisEmailAlreadyExists"));
            RuleFor(x => x.Email).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_EmailNotBeEmpty"));
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_PleaseEnterAValidEmail"));            
            RuleFor(x => x.FullName).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_FullNameNotBeEmpty"));
            RuleFor(x => x.Phone).NotNull()
                .WithMessage(localizer.GetLocalizedHtmlString("lbl_PhoneNotBeEmpty"));
            RuleFor(x => x.IsActive).NotNull();
        }

    }
}