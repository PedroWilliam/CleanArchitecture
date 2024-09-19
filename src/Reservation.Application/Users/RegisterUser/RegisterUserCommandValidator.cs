﻿using FluentValidation;

namespace Reservation.Application.Users.RegisterUser;
internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.Email).EmailAddress().NotEmpty();
        RuleFor(c => c.Password).NotEmpty().MinimumLength(5);
    }
}
