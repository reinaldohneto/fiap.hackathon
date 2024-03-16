using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.Application.Dtos.User;
using FluentValidation;

namespace Fiap.Hackathon.Application.Validators;

public class UserInputDtoValidator : AbstractValidator<UserInputDto>
{
    public UserInputDtoValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(u => u.UserName)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(u => u.Password)
            .NotEmpty();

        RuleFor(u => u.PasswordConfirmation)
            .NotEmpty()
            .Equal(u => u.Password);
    }
}