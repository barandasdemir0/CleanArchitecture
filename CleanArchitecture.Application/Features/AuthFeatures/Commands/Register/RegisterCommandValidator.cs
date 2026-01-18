using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.email).NotEmpty().WithMessage("Mail bilgisi boş olamaz!");
            RuleFor(p => p.email).NotNull().WithMessage("Mail bilgisi boş olamaz!");
            RuleFor(p => p.email).EmailAddress().WithMessage("Geçerli bir mail adresi girin!");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz!");
            RuleFor(p => p.UserName).NotNull().WithMessage("Kullanıcı adı boş olamaz!");
            RuleFor(p => p.UserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır!");
            RuleFor(p => p.password).NotEmpty().WithMessage("Şifre boş olamaz!");
            RuleFor(p => p.password).NotNull().WithMessage("Şifre boş olamaz!");
            RuleFor(p => p.password).Matches("[A-Z]").WithMessage("Şife en az 1 adet büyük harf içermelidir!");
            RuleFor(p => p.password).Matches("[a-z]").WithMessage("Şife en az 1 adet küçük harf içermelidir!");
            RuleFor(p => p.password).Matches("[0-9]").WithMessage("Şife en az 1 adet rakam içermelidir!");
            RuleFor(p => p.password).Matches("[^a-zA-Z0-9]").WithMessage("Şife en az 1 adet özel karakter içermelidir!");
        }
    }
}
