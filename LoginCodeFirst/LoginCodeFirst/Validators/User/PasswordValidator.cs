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
            RuleFor(x => x.Password).NotNull().WithMessage(localizer["Password must not be empty."]);
            RuleFor(x => x.Password).Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer["Password must have both letters and numbers."]);
        }
    }
}