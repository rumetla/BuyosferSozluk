using BuyosferSozluk.Common.Models.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyosferSozluk.Api.Application.Features.Commands.User.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(i => i.EmailAddress)
            .NotNull()
            .EmailAddress()
            .WithMessage("{PropertyName} not a valid email address");
        RuleFor(i => i.Password)
            .NotNull()
            .MinimumLength(6).WithMessage("{PropertyName} should at least be {MinLength} characters");
    }
}
