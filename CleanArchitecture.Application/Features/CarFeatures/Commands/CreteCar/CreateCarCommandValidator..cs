using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreteCar
{
    public sealed class CreateCarCommandValidator:AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Araç Adı Boş Olamaz");
            RuleFor(p => p.Name).NotNull().WithMessage("Araç Adı Boş Olamaz");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Araç Adı 3 karakterden az  Olamaz");


            RuleFor(p => p.Model).NotEmpty().WithMessage("Araç Model Adı Boş Olamaz");
            RuleFor(p => p.Model).NotNull().WithMessage("Araç Model Adı Boş Olamaz");
            RuleFor(p => p.Model).MinimumLength(3).WithMessage("Araç Model Adı 3 karakterden az  Olamaz");


            RuleFor(p => p.EnginePower).NotEmpty().WithMessage("Araç Motor gücü Adı Boş Olamaz");
            RuleFor(p => p.EnginePower).NotNull().WithMessage("Araç Motor gücü Adı Boş Olamaz");
            RuleFor(p => p.EnginePower).GreaterThan(0).WithMessage("Araç Motor gücü  0  az  Olamaz");
        }
    }
}
