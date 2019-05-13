using FluentValidation;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validators
{
    public class IndexValidator : AbstractValidator<IndexViewModel>
    {
        public IndexValidator(IUserServices userServices, IStringLocalizer<IndexValidator> localizer)
        {
            var users = userServices.Users();
            foreach (var user in users)
            {
                RuleFor(x => x.Email).NotEqual(user.Email).WithMessage(localizer["This Email already exists."]);
            }
            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email not be empty"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["must start with a letter"]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["The email must include letters and numbers"]);
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
            RuleFor(x => x.FullName).NotNull().WithMessage(localizer["Fullname not be empty"]);
            RuleFor(x => x.IsActive).NotNull();
            RuleFor(x => x.FullName).NotNull().WithMessage(localizer["Fullname not be empty"]);
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone not be empty"]);
            RuleFor(x => x.IsActive).NotNull();
        }

    }
}