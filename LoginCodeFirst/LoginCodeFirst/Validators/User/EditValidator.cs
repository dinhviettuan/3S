using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators.User
{
    public class IndexValidator : AbstractValidator<EditViewModel>
    {
        public IndexValidator(IUserServices userServices, IStringLocalizer<EditViewModel> localizer)
        {
            var users = userServices.GetUsers();
            foreach (var user in users)
            {
                RuleFor(x => x.Email).NotEqual(user.Email).WithMessage(localizer["This Email already exists."]);
            }
            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email not be empty"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["Please enter a valid email!"]);            
            RuleFor(x => x.FullName).NotNull().WithMessage(localizer["Fullname not be empty"]);
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
            RuleFor(x => x.IsActive).NotNull();
        }

    }
}