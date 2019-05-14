using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation;
using LoginCodeFirst.Models;
using LoginCodeFirst.ViewModels;
using LoginCodeFirst.Services;
using LoginCodeFirst.ViewModels.User;
using Microsoft.Extensions.Localization;

namespace LoginCodeFirst.Validator
{
    public class PasswordValidator : AbstractValidator<PasswordViewModel>
    {
        public PasswordValidator(IUserServices userServices, IStringLocalizer<PasswordValidator> localizer)
        {
            RuleFor(x => x.NewPassword).NotNull().WithMessage(localizer["Password must not be empty."]);
            RuleFor(x => x.NewPassword).MinimumLength(8).WithMessage(localizer["Password not less than 8 characters."]);
            RuleFor(x => x.NewPassword).Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").
                WithMessage(localizer["Password must have both letters and numbers."]);
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage(localizer["Password must not be empty."]);
            RuleFor(x => x.ConfirmPassword).MinimumLength(8).WithMessage(localizer["Password not less than 8 characters."]);
            RuleFor(x => x.ConfirmPassword).Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").
                WithMessage(localizer["Password must have both letters and numbers."]);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword)
                .WithMessage(localizer["Confirm Password must be equal New Password"]);
        }
    }
}