using Fiap.Hackathon.Application.Dtos.Video;
using FluentValidation;

namespace Fiap.Hackathon.Application.Validators;

public class VideoCreateInputDtoValidator : AbstractValidator<VideoCreateInputDto>
{
    public VideoCreateInputDtoValidator()
    {
        RuleFor(v => v.Base64)
            .NotEmpty();

        RuleFor(v => v.Name)
            .NotEmpty();

        RuleFor(v => v.Email)
            .NotEmpty();
    }
}